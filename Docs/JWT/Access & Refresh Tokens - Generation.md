
# 🚀 Generació d'Access Token i Refresh Token

## 📌 **Què és un Access Token i un Refresh Token?**
- **Access Token:** És el token que s'utilitza per a autenticar-se en peticions a l'API durant un període limitat de temps.
- **Refresh Token:** És un token utilitzat per renovar l'Access Token quan aquest expira, sense necessitat que l'usuari torni a iniciar sessió de nou.

## 🛠 **Generació d'Access Token i Refresh Token**

Quan el client fa login, el servidor hauria de generar tant l'Access Token com el Refresh Token.

### 1️⃣ **Generació de l'Access Token:**
L'Access Token es genera per autenticar el client durant un període determinat (per exemple, 15 minuts).

```csharp
var accessToken = GenerateAccessToken(user); // Funció que crea un access token
```

### 2️⃣ **Generació del Refresh Token:**
El Refresh Token es genera per permetre la renovació automàtica de l'Access Token sense necessitat d'iniciar sessió de nou.

```csharp
var refreshToken = GenerateRefreshToken(user); // Funció que crea un refresh token
```

### 3️⃣ **Emmagatzematge de Refresh Token:**
El Refresh Token s'ha de guardar de forma segura, en una **HTTP-only cookie** o en una base de dades. Per exemple, en una cookie HTTP-only:

```csharp
Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
{
    HttpOnly = true, // No accessible per JavaScript
    Secure = true,   // Només per HTTPS
    SameSite = SameSiteMode.Strict, // Evita CSRF
    Expires = DateTime.UtcNow.AddDays(7) // Expiració del refresh token
});
```

### 4️⃣ **Resposta al client:**
Es retorna l'Access Token com a resposta JSON, mentre que el Refresh Token es guarda a la cookie.

```csharp
return Ok(new { accessToken = accessToken });
```

---

## 🔄 **Renovació de l'Access Token amb el Refresh Token**

Quan l'Access Token caduca, el client envia una petició al servidor per renovar-lo utilitzant el Refresh Token.

### 1️⃣ **El client envia la petició de renovació:**
El client fa una petició al servidor amb el Refresh Token, però no l'envia manualment (ja que està emmagatzemat en una HTTP-only cookie).

```csharp
[HttpPost("refresh-token")]
public IActionResult RefreshToken()
{
    if (!Request.Cookies.TryGetValue("refresh_token", out string refreshToken))
    {
        return Unauthorized();
    }

    // Validar refresh token en la BD
    var user = ValidateRefreshToken(refreshToken);
    if (user == null)
    {
        return Unauthorized();
    }

    // Generar nous tokens
    var newAccessToken = GenerateAccessToken(user);
    var newRefreshToken = GenerateRefreshToken(user);

    // Guardar nou refresh token en la BD i a la cookie
    SaveRefreshToken(user, newRefreshToken);
    Response.Cookies.Append("refresh_token", newRefreshToken, cookieOptions);

    return Ok(new { accessToken = newAccessToken });
}
```

---

## 🔑 **Seguretat en la generació i renovació**

- **Access Tokens** tenen un temps de vida curt (ex. 15 minuts), mentre que els **Refresh Tokens** poden durar dies o setmanes.
- Els **Refresh Tokens** s'han de validar a la BD abans de generar un nou Access Token.
- Utilitzar **HTTP-only cookies** per a emmagatzemar el Refresh Token assegura que no sigui accessible per JavaScript, evitant atacs XSS.
- A més, l'ús de **SameSite=Strict** en les cookies ajuda a protegir contra atacs CSRF.

---

## Lligar el Refresh Token a un dispositiu concret

Cada cop que generes un refresh token, pots:
- ✔ Assignar-lo a un dispositiu/IP concret.
- ✔ Guardar un identificador únic en la base de dades.
- ✔ Si es detecta un refresh token utilitzat des d'un dispositiu diferent, es pot bloquejar.

### 📌 Exemple de base de dades amb identificador únic

| ID  | Usuari | Refresh Token (Hash) | Dispositiu | IP            | Expiració    |
| --- | ------ | -------------------- | ---------- | ------------- | ------------ |
| 1   | user1  | abc123xyz            | Chrome     | 192.168.1.10  | 2025-04-01   |
| 2   | user1  | def456uvw            | Mòbil      | 192.168.1.12  | 2025-04-10   |

Si el refresh token s’intenta utilitzar des d'una altra IP o dispositiu no registrat, es pot denegar.

## Com Emmagatzemar el Refresh Token?

- ✔ Opció 1: Base de dades (associat a l'usuari per verificar-lo posteriorment)

- ✔ Opció 2: Redis (si vols un sistema més ràpid i escalable)

- ✔ Opció 3: Cookies segures **HTTP-only cookies** 

## 🔒 **Conclusió**

Sí, has de generar tant l'Access Token com el Refresh Token.  
- **L'Access Token** s'utilitza per a autenticar les peticions a l'API durant un període limitat.  
- **El Refresh Token** permet renovar l'Access Token sense necessitat de tornar a iniciar sessió.

Utilitzant **HTTP-only cookies** i seguint les bones pràctiques de seguretat, pots assegurar un sistema segur per a la gestió de tokens en la teva aplicació.
