# 🔒 Seguretat amb Refresh Tokens i HTTP-only Cookies

## 📌 **Per què és segur emmagatzemar el refresh token en una HTTP-only cookie?**  
✅ **No és accessible per JavaScript** (evita atacs **XSS**).  
✅ **Només s'envia automàticament al servidor** en cada petició al domini (no es pot robar amb JavaScript).  
✅ **Es pot protegir amb "Secure" i "SameSite"** per evitar atacs **CSRF**.

---

## 🛡 **Flux segur amb HTTP-only cookies**
Quan el client necessita renovar el seu access token, el procés segur seria:

### 1️⃣ **Autenticació inicial:**  
- El client fa login amb usuari/contrasenya.  
- El servidor genera un **access token** i un **refresh token**.  
- L’**access token** es retorna com a resposta JSON.  
- El **refresh token** es guarda en una HTTP-only cookie.

```csharp
Response.Cookies.Append("refresh_token", refreshToken, new CookieOptions
{
    HttpOnly = true, // No accessible per JavaScript
    Secure = true,   // Només per HTTPS
    SameSite = SameSiteMode.Strict, // Evita CSRF
    Expires = DateTime.UtcNow.AddDays(7) // Expiració del refresh token
});
```

### 2️⃣ **El client fa servir l'access token** per a cada petició.  
- S’envia el token com a **header** en les peticions protegides (`Authorization: Bearer <token>`).  
- Quan caduca, el client detecta un error **401 Unauthorized**.

### 3️⃣ **Renovació del token (utilitzant el refresh token)**  
- El client fa una petició al servidor (`/refresh-token`).  
- **No envia el refresh token manualment** ❌  
- ✅ El navegador **l’envia automàticament** perquè està en una HTTP-only cookie.  
- El servidor llegeix la cookie, valida el refresh token i genera un nou access token.  
- Es retorna el nou access token al client.  

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

### 4️⃣ **Si un atacant intenta robar el refresh token, no pot accedir-hi**  
- No està disponible per JavaScript (evita **XSS**).  
- Només es pot enviar al servidor des del mateix domini (evita **CSRF** amb `SameSite=Strict`).  
- Si el refresh token s’intenta utilitzar des d'un altre dispositiu, es pot detectar i bloquejar.

---

## 🔒 **Conclusió**
✔ **El client no ha d'enviar manualment el refresh token** → Es guarda en una HTTP-only cookie.  
✔ **Això protegeix contra atacs XSS i CSRF**.  
✔ **El servidor controla i valida els refresh tokens** a la BD per detectar activitats sospitoses.  

D’aquesta manera, el procés de renovació dels access tokens es fa de manera segura! 🚀

