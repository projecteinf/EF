# Class / Tipus Object

Totes les classes depenen del tipus Object. Per herència, totes les classes defineixen els camps i mètodes del tipus Object.

# Mètodes

## Constructor

Object() 	 Crea una nova instància de la classe Object

## Mètodes

| Nom   | Funcionalitat  |
|--------------|---------|
| Equals(Object, Object) | Determines whether the specified object instances are considered equal. |
| Equals(Object)	| Determines whether the specified object is equal to the current object. |
| Finalize() | Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection. |
| GetHashCode() | Serves as the default hash function. |
| GetType() | Gets the Type of the current instance. |
| MemberwiseClone() | Nova instància de l'objecte. Si conté altres objectes, no es crea una nova instància dels "subojectes" (shallow copy). |
| ReferenceEquals(Object, Object) | Determines whether the specified Object instances are the same instance. |
| ToString() | Returns a string that represents the current object. |

Si la nostra classe o tipus precisa modificar el comportament de qualsevol de les funcionalitats (mètodes) de la classe Object, haurem de sobreescriure el mètode en la nostra classe.

# Consideracions d'eficiència - Tipus <T>

Performance considerations

If you're designing a class, such as a collection, that must handle any type of object, you can create class members that accept instances of the Object class. However, the process of boxing and unboxing a type carries a performance cost. If you know your new class will frequently handle certain value types you can use one of two tactics to minimize the cost of boxing.

    Create a general method that accepts an Object type, and a set of type-specific method overloads that accept each value type you expect your class to frequently handle. If a type-specific method exists that accepts the calling parameter type, no boxing occurs and the type-specific method is invoked. If there is no method argument that matches the calling parameter type, the parameter is boxed and the general method is invoked.
    Design your type and its members to use generics. The common language runtime creates a closed generic type when you create an instance of your class and specify a generic type argument. The generic method is type-specific and can be invoked without boxing the calling parameter.

Although it's sometimes necessary to develop general purpose classes that accept and return Object types, you can improve performance by also providing a type-specific class to handle a frequently used type. For example, providing a class that is specific to setting and getting Boolean values eliminates the cost of boxing and unboxing Boolean values.

### Exemple

```CSharp
using System;
using System.Diagnostics;
using static System.Console;

using System;
using System.Diagnostics;

public class GenericPerformanceConsiderations<T>
{
    public void Process(T value)
    {
        string s = value.ToString(); // Correcció aquí
    }
}

public class PerformanceConsiderations
{
    public void Process(object value)
    {
        string s = value.ToString();
    }

    public void Process(int value)
    {
        string s = value.ToString();
    }

    public void Process(bool value)
    {
        string s = value.ToString();
    }
}

class Program
{
    static void Main()
    {
        var nonGeneric = new PerformanceConsiderations();
        var genericInt = new GenericPerformanceConsiderations<int>();
        var genericBool = new GenericPerformanceConsiderations<bool>();

        Stopwatch sw = new Stopwatch();
        long nonGenericTotal = 0;
        long genericTotal = 0;

        // Executa múltiples vegades per tenir un temps mitjà
        for (int j = 0; j < 10; j++)
        {
            // Mesura PerformanceConsiderations
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                nonGeneric.Process(42);
                nonGeneric.Process(true);
            }
            sw.Stop();
            nonGenericTotal += sw.ElapsedTicks; // Millor precisió amb Ticks

            // Mesura GenericPerformanceConsiderations
            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                genericInt.Process(42);
                genericBool.Process(true);
            }
            sw.Stop();
            genericTotal += sw.ElapsedTicks;
        }

        WriteLine("\nNon-generic time (avg): " + (nonGenericTotal / 10) + " ticks");
        WriteLine("Generic time (avg): " + (genericTotal / 10) + " ticks");
    }
}

```
## Resultats
    Non-generic time (avg): 12.462.058 ticks
    Generic time (avg): 11.822.749 ticks

Utilitzar sobreescritura pels tipus és més eficient que una classe de tipus genèrica.

## Classe PerformanceConsiderations vs GenericPerformanceConsiderations<T>

GenericPerformanceConsiderations<T> ticks d'execució: 12.462.058 ticks
PerformanceConsiderations ticks d'execució: 11.822.749 ticks


Encara que PerformanceConsiderations sigui més eficient per a tipus de valor (int, bool, etc.), 

```bash 
public void Process(object value)
{
    Console.WriteLine(value);
}

int number = 42;
Process(number);  // 🔴 Aquí es fa boxing perquè int ha de convertir-se en object
```

els genèrics són útils en altres situacions, com ara:

✔ Si has de treballar amb tipus de referència (string, List<T>, object) . No hi ha boxing, per naturalesa ja són objectes.

```bash
public void Process(object value)
{
    Console.WriteLine(value);
}

string text = "Hola";
Process(text);  // ✅ NO hi ha boxing, perquè string ja és un objecte. La penalització és molt menor que en el cas anterior
```


✔ Si la classe ha de ser flexible i treballar amb molts tipus diferents: si necessites gestionar molts tipus de dades sense voler escriure milers de sobrecàrregues, els genèrics són una bona solució.

✔ Si el rendiment no és una preocupació crítica: en aplicacions normals, la diferència pot no ser significativa i els genèrics poden facilitar la mantenibilitat. En aplicacions de joc, cal evitar l'utilització de tipus genèrics per a millorar al màxim el seu rendiment.

# Referències

[https://learn.microsoft.com/en-us/dotnet/api/system.object?view=net-9.0](https://learn.microsoft.com/en-us/dotnet/api/system.object?view=net-9.0)
[https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-object](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-object)

