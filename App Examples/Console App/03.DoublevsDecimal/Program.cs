Console.WriteLine("Double vs Decimal");

Console.WriteLine("Double");
double pes1 = 0.1;
double pes2 = 0.2;

Console.WriteLine($"\t\t{pes1} + {pes2} = {pes1 + pes2}");

if (pes1 + pes2 == 0.3)
{
    Console.WriteLine($"\t\t{pes1} + {pes2} = 0.3");
}
else
{
    Console.WriteLine($"\t\t{pes1} + {pes2} != 0.3");
}

decimal pes3 = 0.1M;
decimal pes4 = 0.2M;

Console.WriteLine("Decimal");
Console.WriteLine($"\t\t{pes3} + {pes4} = {pes3 + pes4}");

if (pes3 + pes4 == 0.3M)
{
    Console.WriteLine($"\t\t{pes3} + {pes4} = 0.3");
}
else
{
    Console.WriteLine($"\t\t{pes3} + {pes4} != 0.3");
}

Console.WriteLine("NO utilitzeu double per a càlculs que requereixin exactitud, utilitzeu decimal");