using System;
using System.Collections.Generic;
using static System.Console;


public class Program {
    public static void Main() {
        List<Persona> persones = GetPersones();
        persones.Sort();    
        WriteLine("Ordenat per edat: de menor a major");
        Imprimir(persones);
        persones.Reverse();
        WriteLine("Ordenat per edat: de major a menor");
        Imprimir(persones);

        persones = GetPersones();
        WriteLine("Persones desornades - Abans de començar ordenació per classe");
        persones.Sort(new PersonaComparador());
        WriteLine("Ordenat per edat: de menor a major edat");
        Imprimir(persones);

        persones = GetPersones(); 
        WriteLine("Ordenar per edat");
        persones.Sort(new PersonaComparador<int>(p => p.Edat));
        Imprimir(persones);

        WriteLine("Ordenar alfabèticament per nom");
        persones.Sort(new PersonaComparador<string>(p => p.Nom));
        Imprimir(persones);

        WriteLine("Ordenar per edat: de major a menor");
        persones.Sort(new PersonaComparador<int>(p => p.Edat, ordreInvers: true));
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

