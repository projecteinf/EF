# Classes

```csharp
using System;
namespace Packt.Shared {
    public class Person
    {

    }
}
```

# "Members"
"Members": camps (fields), mètodes (methods) , o "specialized".

## Fields
Utilitzats per a emmagatzemar informació. 

- Constant
- Read-only:  inicialització quan es crea l'objecte. No es pot canviar.
- Read-Write: es pot llegir i escriure.
- Event: es dispara quan passa alguna cosa: clicar un botó, entrar dins un camp del formulari...

## Methods
S'utilitzen per a l'execució de sentències.

- Constructor: s'executa quan es crea un objecte (new keyword).
- Property: s'executen quan es llegeixen o s'escriuen dades. Les dades s'emmagatzemen normalment en un camp (field). Tenen la funció d'encapsular els camps. 
- Indexer: permeten accedir a un objecte com si fos un array.
- Operator: permeten sobrecarregar operadors com +, -, *, /, etc.

## Exemple

```csharp
using System;
namespace BoscComa.Shared {
    public class Person
    {
        private string _name; // camp o field de tipus Read-Write
        ...
        public string Name  // propietat o property
        {
            get { return _name; }
            set { _name = value; }
        }
        ...
    }
}
/*
    Accedim a la propietat Name de la classe Person a través del nom de la propietat.
        Person person = new Person();
        person.Name = "Alice";
        Console.WriteLine(person.Name);
*/
```