using System;
using System.Collections.Generic;
using static System.Console;


public class Program {
    public static void Main() {
        List<Persona> persones = new List<Persona>();
        persones.Add(new Persona("Anna",30,"77332312"));
        persones.Add(new Persona("Miquel",35,"77332312"));
        persones.Add(new Persona("Pere",8,"77332312"));
        persones.Add(new Persona("Maria",10,"77332312"));

        persones.Sort();    // persones.Reverse
        foreach (Persona persona in persones) {
            Console.WriteLine($"{persona.Nom} - {persona.Edat}");
        }
    }
}

