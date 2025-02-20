# Creació classe personalitzada - Gestió d'errors
Per a personalitzar la gestió dels errors de les classes que dissenyem creem una nova classe que hereda de la classe .NET Exception.
```CSharp
using System;
namespace BoscComa.GestioErrors
{
    public class PersonaException : Exception
    {
        public PersonaException() : base() { }
        public PersonaException(string message) : base(message) { }
        public PersonaException(string message, Exception innerException): base(message, innerException) { }
    }
}
```
Com que els constructors no s'hereden, la nostra classe cal que declari i referenci als constructors de la classe pare (Exception)  
