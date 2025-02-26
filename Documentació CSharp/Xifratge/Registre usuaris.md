# Registre usuaris
Quan registrem usuaris a la base de dades ens hem de preocupar de que la informació s'emmagatzemi de forma segura i que no es puguin desencriptar els passwords amb atacs de diccionari o de força bruta. Un hacker pot aconseguir accés a la base de dades, però li hem de dificultar el màxim la desencriptació dels mots claus.  
## Prevenció atacs de diccionari.
Sempre hem de generar una cadena de hash diferent, encara que dos usuaris es registrin amb el mateix password. La idea per aconseguir aquest objectiu és concatenar el password a una informació que sigui sempre diferent **salt**.
### Salt
* Ha de ser sempre diferent en contingut i en estructura (no podem utilitzar uuid com a cadena de salt).  
* Array de bytes (informació binària).  
* Cal emmagatzemar el salt a la base de dades per poder xifrar de la mateixa forma el password introduït per l'usuari en el procés d'autentificació.
```CSharp
static byte[] GenerateSalt(int size)
{
    byte[] salt = new byte[size];
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(salt);
    }
    return salt;
}
``` 
## Prevenció d'atacs de força bruta
Per evitar els atacs de força bruta cal alentir el procés de generació del hash. La idea és aplicar l'algoritme de hash N vegades.
```CSharp
Hash1 = HMAC_SHA256(password + salt);
Hash2 = HMAC_SHA256(Hash1);
Hash3 = HMAC_SHA256(Hash2);
...
```
Amb aquesta estratègia aconseguim que el procés d'obtenció del hash final sigui més lent i, per tant, dificultem la desencriptació dels mots claus utilitzant maquinari especialitzat o mitjançant força bruta.
# Aplicació a CSharp


```CSharp
using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string password = "superSecretPassword"; // Contrasenya de l'usuari
        byte[] salt = GenerateSalt(16); // Genera un salt aleatori de 16 bytes
        int iterations = 100000; // Iteracions recomanades per PBKDF2 (100.000 o més)

        // Genera el hash del password usant PBKDF2
        byte[] passwordHash = HashPassword(password, salt, iterations);

        // Convertim a Base64 per guardar a la base de dades
        string base64Salt = Convert.ToBase64String(salt);
        string base64Hash = Convert.ToBase64String(passwordHash);

        Console.WriteLine($"Salt (Base64): {base64Salt}");
        Console.WriteLine($"Password Hash (Base64): {base64Hash}");
    }

    // Funció per generar un salt segur
    static byte[] GenerateSalt(int size)
    {
        byte[] salt = new byte[size];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    // Funció per generar el hash de la contrasenya amb PBKDF2
    static byte[] HashPassword(string password, byte[] salt, int iterations)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(32); // Genera un hash de 256 bits (32 bytes)
        }
    }
}
```