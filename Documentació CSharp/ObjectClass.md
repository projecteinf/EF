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

using System;
using System.Diagnostics;

public class PerformanceConsiderations
{
    // General method that accepts an Object type (may involve boxing)
    public void Process(object value)
    {
        Console.WriteLine("Processing object: " + value);
    }

    // Type-specific method overload for int (avoids boxing)
    public void Process(int value)
    {
        Console.WriteLine("Processing int: " + value);
    }

    // Type-specific method overload for bool (avoids boxing)
    public void Process(bool value)
    {
        Console.WriteLine("Processing bool: " + value);
    }
}

public class GenericPerformanceConsiderations<T>
{
    // Generic method (avoids boxing for value types)
    public void Process(T value)
    {
        Console.WriteLine("Processing generic type: " + value);
    }
}

class Program
{
    static void Main()
    {
        var nonGeneric = new PerformanceConsiderations();
        var genericInt = new GenericPerformanceConsiderations<int>();
        var genericBool = new GenericPerformanceConsiderations<bool>();

        // Measure performance for non-generic class
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < 1000000; i++)
        {
            nonGeneric.Process(42);       // Calls type-specific method (no boxing)
            nonGeneric.Process(true);     // Calls type-specific method (no boxing)
            nonGeneric.Process("hello");  // Calls general method (boxing for value types)
        }
        sw.Stop();
        Console.WriteLine("Non-generic time: " + sw.ElapsedMilliseconds + " ms");

        // Measure performance for generic class
        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            genericInt.Process(42);       // Calls generic method (no boxing)
            genericBool.Process(true);    // Calls generic method (no boxing)
        }
        sw.Stop();
        Console.WriteLine("Generic time: " + sw.ElapsedMilliseconds + " ms");
    }
}

# Referències

[https://learn.microsoft.com/en-us/dotnet/api/system.object?view=net-9.0](https://learn.microsoft.com/en-us/dotnet/api/system.object?view=net-9.0)
[https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-object](https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-object)

