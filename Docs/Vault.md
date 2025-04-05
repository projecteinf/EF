# Manual bàsic: HashiCorp Vault amb Docker i persistència

## Per què utilitzar Vault?

En moltes aplicacions, les credencials (contrasenyes, claus d'API, tokens d'accés...) es guarden dins del codi font o en fitxers de configuració. Això representa un risc de seguretat molt alt:

- Poden filtrar-se en repositoris de codi
- Poden ser llegides per usuaris no autoritzats
- Són difícils de canviar o gestionar de forma centralitzada

**HashiCorp Vault** és una eina pensada per resoldre aquests problemes:

### Avantatges de Vault:
- Emmagatzematge segur de secrets
- Control d'accés per usuaris i aplicacions
- Auditories i registre d'accessos
- Suport per secrets dinàmics (claus temporals)
- Xifrat automàtic a disc

Vault pot funcionar en local (com veuràs en aquest manual) o en entorns cloud. Aquest document explica com utilitzar-lo en local amb Docker i dades persistents.

### Comparació: guardar secrets en fitxer xifrat vs. usar Vault

| Mètode                            | Avantatges                            | Inconvenients                                                   |
|-----------------------------------|----------------------------------------|-----------------------------------------------------------------|
| **String xifrat en fitxer**       | Fàcil d'implementar                    | Claus d'encriptació han d'estar accessibles, risc de filtració |
| **Vault (o secret manager)**      | Xifrat + control d'accés + auditories | Més complex, requereix desplegament i manteniment              |


## 1. Crear un volum Docker
```bash
docker volume create vault-data
```

## 2. Iniciar Vault amb persistència (sense TLS)
```bash
docker run --cap-add=IPC_LOCK \
  -e 'VAULT_LOCAL_CONFIG={"storage": {"file": {"path": "/vault/data"}}, "listener": {"tcp": {"address": "0.0.0.0:8200", "tls_disable": 1}}}' \
  -p 8200:8200 \
  -v vault-data:/vault/data \
  --name vault-persistent \
  -d hashicorp/vault
```

## 3. Inicialitzar Vault
```bash
docker exec -it vault-persistent sh
vault operator init
```

> Guarda:
> - Les **5 Unseal Keys**
> - El **Root Token**

## 4. Desbloquejar Vault (Unseal)
Executar **3 cops** amb claus diferents:
```bash
vault operator unseal
```

## 5. Login com a root
```bash
vault login
```
Introdueix el **Root Token**.

## 6. Activar el motor de secrets (kv)
```bash
vault secrets enable -path=secret kv
```

## 7. Desar un secret
```bash
vault kv put secret/myapp password=supersecret
```

## 8. Llegir el secret
```bash
vault kv get secret/myapp
```

## 9. Accedir al secret des de C#
```csharp
var client = new HttpClient();
client.BaseAddress = new Uri("http://127.0.0.1:8200");
client.DefaultRequestHeaders.Add("X-Vault-Token", "root");

var response = await client.GetAsync("/v1/secret/data/myapp");
response.EnsureSuccessStatusCode();

var json = await response.Content.ReadAsStringAsync();
using var doc = JsonDocument.Parse(json);
var password = doc.RootElement
                  .GetProperty("data")
                  .GetProperty("data")
                  .GetProperty("password")
                  .GetString();

Console.WriteLine($"Password secret: {password}");
```

---

Ara tens un Vault funcional amb dades persistents. Vols afegir algun apartat extra (reinici, permisos, més secrets)?

