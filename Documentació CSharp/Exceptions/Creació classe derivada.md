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
# Utilització classe personalitzada
```CSharp
class Persona {
    public void Historic(DateTime quan, string fet)
    {
        // Enlloc de relacionar amb la DataNaixement, es podria relacionar amb el fet -> Treure carnet de conduir, obtenir títol CFGM, obtenir títol CFGS...
        if (quan <= this.DataNaixement) 
        {
            throw new PersonaException("Pots viatjar en el temps :-o");
        }
        else
        {
            // Registrar fet
        }
    }
}

class Program {
    static void Main() {
        try
        {
            p1.Historic(new DateTime(1999, 12, 31),"Obtenció títol CFGS"); 
        }
        catch (PersonException ex)
        {
            WriteLine(ex.Message);
        }
    }
}
```