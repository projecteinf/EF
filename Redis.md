# Ús de Redis per guardar tokens amb C#

## Què és Redis?
- Redis és una **base de dades in-memory**, però **suporta persistència** mitjançant:
  - **RDB** (snapshots)
  - **AOF** (log d’operacions)
  - Combinació de RDB + AOF

## Bases de dades
- Redis ofereix **16 bases de dades numerades (0-15)**.
- No es poden donar noms, però es poden seleccionar amb `SELECT <n>` o via codi:
  ```csharp
  redis.GetDatabase(database: 1);
  ```

## Estructura de dades per guardar tokens
- Redis no té taules/col·leccions, però es poden simular amb **claus prefixades** i **hashes**.
- Exemple per guardar un *refresh token* amb informació:
  ```bash
  HSET refresh:<token_id> user_id 123 ip 192.168.1.10 expires 2025-03-30T10:00:00Z
  ```

## Exemple en C# amb StackExchange.Redis

### Instal·lació:
```bash
dotnet add package StackExchange.Redis
```

### Codi bàsic:
```csharp
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var redis = await ConnectionMultiplexer.ConnectAsync("localhost");
        var db = redis.GetDatabase(database: 1); // escollim base de dades 1

        var token = new Token
        {
            RefreshToken = "abc123",
            AccessToken = "xyz789"
        };

        string userId = "123";
        string userIp = "192.168.1.10";
        string key = $"refresh:{token.RefreshToken}";

        await db.HashSetAsync(key, new HashEntry[]
        {
            new HashEntry("user_id", userId),
            new HashEntry("ip", userIp),
            new HashEntry("expires", DateTime.UtcNow.AddDays(7).ToString("o"))
        });

        await db.KeyExpireAsync(key, TimeSpan.FromDays(7));

        var allFields = await db.HashGetAllAsync(key);
        foreach (var field in allFields)
        {
            Console.WriteLine($"{field.Name}: {field.Value}");
        }
    }
}

class Token
{
    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }
}
```

## Notes:
- El `key` (`refresh:<refresh_token>`) és com una clau primària que apunta a una hash.
- No hi ha índexs automàtics: si vols buscar per `user_id`, cal mantenir índexs manuals o usar RedisSearch.
- Per afegir caducitat automàtica:
  ```csharp
  await db.KeyExpireAsync(key, TimeSpan.FromDays(7));
  ```