using System;
using static System.Console;

class Program {

    static void Main() {
        TextAndNumber textAndNumber = Processor.GetTheData();
        WriteLine($"{textAndNumber.Text}, {textAndNumber.Number}");

        (string,int) textAndNumberTuple = Processor.GetTheDataWithTuple();  
        WriteLine($"{textAndNumberTuple.Item1}, {textAndNumberTuple.Item2}");
    }
}

