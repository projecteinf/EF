using System;
using static System.Console;

class Program {

    static void Main() {
        TextAndNumber textAndNumber = Processor.GetTheData();   // Retornem un objecte
        WriteLine($"{textAndNumber.Text}, {textAndNumber.Number}");

        (string,int) textAndNumberTuple = Processor.GetTheDataWithTuple();  // Retornem una tupla sense noms assignats
        WriteLine($"{textAndNumberTuple.Item1}, {textAndNumberTuple.Item2}");      

        var textAndNumberTupleWithNames = Processor.GetTheDataTupleWithNames();  // Retornem una tupla amb noms assignats
        WriteLine($"{textAndNumberTupleWithNames.Text}, {textAndNumberTupleWithNames.Numero}");

        (string Text, int Number) textAndNumberTupleWithoutNames = Processor.GetTheDataWithTuple();    // Retornem una tupla sense noms assignats i assignem noms quan rebem els valors
        WriteLine($"{textAndNumberTupleWithoutNames.Text}, {textAndNumberTupleWithoutNames.Number}");
    }
}

