using System;
using System.Collections.Generic;
using static System.Console;


public class Program {
    public static void Main() {
        List<Persona> persones = GetPersones();
        persones.Sort();    
        WriteLine("Llistat de persones ordenat per edat: de menor edat a major edat");
        Imprimir(persones);
        persones.Reverse();
        WriteLine("Llistat de persones ordenat per edat: de major edat a menor edat");
        Imprimir(persones);

        persones = GetPersones();
        WriteLine("Persones desornades - Abans de començar ordenació per classe");
        persones.Sort(new PersonaComparador());
        WriteLine("Llistat de persones ordenat per edat: de menor edat a major edat");
        Imprimir(persones);
    }
    public static List<Persona> GetPersones() {
        List<Persona> persones = new List<Persona>();
        persones.Add(new Persona("Anna",30,"77332312"));
        persones.Add(new Persona("Miquel",35,"77332312"));
        persones.Add(new Persona("Pere",8,"77332312"));
        persones.Add(new Persona("Maria",10,"77332312"));
        return persones;
    }

    public static void Imprimir(List<Persona> persones) {
        foreach (Persona persona in persones) {
            WriteLine($"{persona.Nom} - {persona.Edat}");
        }
    }
}

