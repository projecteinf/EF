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

