using System;
using static System.Console;

class Program {
    static void Main() {
        Persona persona = new Persona("Anna");
        WriteLine(persona.ToString());  
        WriteLine(persona.ToStringNew());  
        WriteLine("----------------------------------------------------------------------------");

        Treballador treballador = new Treballador("David", "17-3333213-21");
        WriteLine(treballador.ToString());  
        WriteLine(treballador.ToStringNew());  
        WriteLine("----------------------------------------------------------------------------");

        Persona refPersona = new Treballador("Eva", "98-1234567-89"); 
        WriteLine(refPersona.ToString());  
        WriteLine(refPersona.ToStringNew());  
    }
}

