using System;
using System.Collections.Generic;
using static System.Console;
class Program {
    static void Main() {
        Person person=new Person("Jordi",0);        
        person.Shout = ShoutPerson; // Associem el delegat a la funció

        WriteLine("Es pot tranquilitzar...");
        for(short i=0;i<5;i++) {
            WriteLine($"Bufetada: {i+1}");
            person.Bufetejar();
        }

        person.NivellIra = 0;
        person.Shout = ShoutPersonNoEsCalma; // Associem el delegat a la funció
        
        WriteLine("No es pot tranquilitzar...");
        for(short i=0;i<5;i++) {
            WriteLine($"Bufetada: {i+1}");
            person.Bufetejar();
        }
    }
        
    static void ShoutPerson(object? sender, EventArgs eventArgs) {
        //Person person = (Person)sender; -> La línia 17 comprova que l'objecte sigui un Person i l'assigna a person
        if (sender is Person person) { 
            WriteLine($"{person.Nom} que es calma està molt emprenyat: {person.NivellIra}");
            person.Premiar();
        }
    }

    static void ShoutPersonNoEsCalma(object? sender, EventArgs eventArgs) {
        //Person person = (Person)sender; -> La línia 17 comprova que l'objecte sigui un Person i l'assigna a person
        if (sender is Person person) { 
            WriteLine($"{person.Nom} que NO es calma està molt emprenyat: {person.NivellIra}");
        }
    }
}
