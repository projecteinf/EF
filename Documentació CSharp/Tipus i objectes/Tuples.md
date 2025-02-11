# Tuples

S'utilitzen quan volem tornar una combinació de múltiples valors pels quals no hem definit una classe (i no té sentit definir-la).

# Exemple

```CSharp
public class TextAndNumber
{
    public string Text;
    public int Number;
}

public class Processor
{
    public static TextAndNumber GetTheData()
    {
        return new TextAndNumber
        {
            Text = "Número parell",
            Number = 42
        };
    }

    public static (string, int) GetTheDataWithTuple()
    {
        return ("Número parell",  42);
    }
}

```

Podem simplificar el codi de forma important utilitzant una Tupla

```CSharp
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
```

# Assignació de noms als camps de la tupla

La nomenclatura que utilitzarem pels noms de la tupla serà la mateixa definida per als camps dels tipus.

```CSharp
    public static (string Text, int Numero) GetTheDataTupleWithNames()
    {
        return (Text: "Número parell", Numero: 42); // equival a return ("Número parell", 42); Els noms de la tupla es determinen a partir de la signatura del mètode
    }

    var textAndNumberTupleWithNames = Processor.GetTheDataTupleWithNames();  // Retornem una tupla amb noms assignats
    WriteLine($"{textAndNumberTupleWithNames.Text}, {textAndNumberTupleWithNames.Numero}");

    (string Text, int Number) textAndNumberTupleWithoutNames = Processor.GetTheDataWithTuple();    // Retornem una tupla sense noms assignats i assignem noms quan rebem els valors
    WriteLine($"{textAndNumberTupleWithoutNames.Text}, {textAndNumberTupleWithoutNames.Number}");
```
