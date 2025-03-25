# 🔐 Seguretat en la Generació de Tokens JWT en .NET

## 📝 Opció 1: Clau Simètrica (HMAC)

El codi actual utilitza una **clau simètrica** (`SymmetricSecurityKey` amb HMAC-SHA256). Això significa que la mateixa clau s'utilitza tant per **signar** com per **validar** els tokens.

### 🔴 Riscos

- **Si la clau es filtra**, qualsevol pot generar tokens vàlids.
- **Ha de romandre secreta** a tota la infraestructura.
- **Difícil de rotar** sense invalidar tokens existents.

### ✅ Com protegir la clau simètrica?

Si continues amb una clau simètrica, la millor pràctica és **no emmagatzemar-la en codi**. Opcions segures:

#### 1️⃣ Gestor de Secrets de .NET

- Desa la clau al **Secret Manager** de .NET durant el desenvolupament:
  ```sh
  dotnet user-secrets set "Jwt:SecretKey" "una-clau-secreta-segura"
  ```
- I després la recuperes al teu codi:
  ```csharp
  IConfiguration configuration = new ConfigurationBuilder()
      .AddUserSecrets<Program>()
      .Build();
  string key = configuration["Jwt:SecretKey"];
  ```

#### 2️⃣ Variables d'entorn (en producció)

```sh
export JWT_SECRET_KEY="una-clau-secreta-segura"
```

I en el teu codi:

```csharp
string key = Environment.GetEnvironmentVariable("JWT_SECRET_KEY");
```

#### 3️⃣ Azure Key Vault / AWS Secrets Manager

Si treballes en un entorn cloud, pots emmagatzemar la clau en serveis segurs com:

- **Azure Key Vault**
- **AWS Secrets Manager**
- **HashiCorp Vault**

---

## 🏛️ Opció 2: Claus Asimètriques (RSA o ECDSA)

Amb **claus asimètriques**, tens **una clau privada per signar** i **una clau pública per validar**. Això resol el problema de compartir la clau perquè:

- **Només el servidor pot signar tokens**.
- **Qualsevol amb la clau pública pot verificar-los**, sense necessitat de tenir la clau privada.

### ✅ Avantatges

- **Més segur**: Encara que la clau pública es filtri, ningú podrà generar tokens falsos.
- **Escalable**: Diferents serveis poden validar tokens sense accedir a la clau privada.
- **Fàcil rotació**: Pots generar noves claus i distribuir només la pública.

### 🔧 Implementació d'RSA a .NET

#### 1️⃣ Genera un parell de claus (RSA)

```sh
openssl genrsa -out private.key 2048
openssl rsa -in private.key -pubout -out public.key
```

#### 2️⃣ Carrega la clau privada per signar tokens

```csharp
var privateKey = File.ReadAllText("private.key");
var rsa = RSA.Create();
rsa.ImportFromPem(privateKey);

var signingKey = new RsaSecurityKey(rsa);
var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256);
```

#### 3️⃣ Carrega la clau pública per validar-los

```csharp
var publicKey = File.ReadAllText("public.key");
var rsa = RSA.Create();
rsa.ImportFromPem(publicKey);

var validationKey = new RsaSecurityKey(rsa);
```

---

## 🎯 Conclusió: Quina opció és millor?

| **Mètode**                            | **Seguretat**                       | **Facilitat d'implementació** | **Escalabilitat**                 |
| ------------------------------------- | ----------------------------------- | ----------------------------- | --------------------------------- |
| 🔐 **Clau Simètrica (HMAC)**          | Més vulnerable si la clau es filtra | Fàcil                         | Difícil si tens múltiples serveis |
| 🔑 **Claus Asimètriques (RSA/ECDSA)** | Més segur                           | Més complex                   | Escalable, ideal per microserveis |

### **Quan triar cada opció?**

- **Si només el teu backend genera i valida tokens → Simètric (HMAC) pot ser suficient.**
- **Si diferents serveis han de validar tokens → Asimètric (RSA) és la millor opció.**

Si el teu projecte és una **API que serà consumida per diversos serveis**, la millor pràctica és fer servir **claus asimètriques**. Si només ho utilitzes **internament** dins d'una única aplicació, pots gestionar la clau simètrica amb un gestor de secrets i evitar problemes.

