# Guia de nomenclatura - API

Aquest document inclou les recomanacions relacionades amb la nomenclatura dels identificadors específics del codi de l'API: noms de mètodes, funcions, classes, propierats, o altres elements del codi que conformen l'API.

## Recomanacions


✔️ Utilitza un nom similar al de l'antiga API en crear noves versions d'una API existent. Afegeix un sufix en lloc d'un prefix per indicar una nova versió d'una API existent. Els desenvolupadors poden identificar fàcilment les versions de l'API.


**NOMENCLATURA CORRECTE**

```csharp

namespace API.V1
{
    public class UserController
    {
        public List<User> GetUsers() { ... }
        public User GetUser(int id) { ... }
    }
}

namespace API.V2
{
    public class UserController
    {
        public List<User> GetUsersV2(bool includeInactive) { ... }
        public User GetUserV2(string uid) { ... }
    }
}
```

Visualització de la documentació de l'API o navegació. Facilitat la localització de les diferents versions de cada mètode.

```
User GetUser(int id);
User GetUserV2(string uid);
List<User> GetUsers();
List<User> GetUsersV2(bool includeInactive)
```

**NOMENCLATURA INCORRECTE**

```csharp

namespace API.V1
{
    public class UserController
    {
        public List<User> GetUsers() { ... }
        public User GetUser(int id) { ... }
    }
}

namespace API.V2
{
    public class UserController
    {
        public List<User> V2GetUsers(bool includeInactive) { ... }
        public User V2GetUser(string uid) { ... }
    }
}

```

Visualització de la documentació de l'API o navegació. 

```
User V2GetUser(string uid);
List<User> V2GetUsers(bool includeInactive)
User GetUser(int id);
List<User> GetUsers();

```

✔️ Quan la funcionalitat ha canviat de forma significativa cal valorar la possibilitat d'utilitzar un identificador nou, però significatiu, en lloc d'afegir un sufix o un prefix.

```csharp

namespace API.V1
{
    public class ImageLoader
    {
        public Image LoadImage(string filePath) { ... }
    }
    
}

namespace API.V2
{
    public class ImageLoader
    {
        // LoadBitmap és un nom més significatiu que LoadImage per a la funcionalitat del mètode.
        public Bitmap LoadBitmap(string filePath f) { ... }
    }
}
```
