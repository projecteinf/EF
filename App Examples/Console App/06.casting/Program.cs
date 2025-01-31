using System;
using static System.Console;

namespace casting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implicit casting
            int myInt = 9;
            double myDouble = myInt;
            WriteLine($"Implicit casting: int: {myInt} , double: {myDouble}");

            myDouble = 9.78;
            // Explicit casting
            myInt = (int)myDouble;  // (int) is a cast operator
            WriteLine($"Explicit casting (int): int: {myInt} , double: {myDouble}");

            // Convert class
            WriteLine($"Convert cast ToString().: int: {Convert.ToString(myInt)}");
            WriteLine($"Convert cast ToDouble().: int: {Convert.ToDouble(myInt)}");
            WriteLine($"Convert cast ToInt32().: double: {Convert.ToInt32(myDouble)}");
            WriteLine($"Convert cast ToInt32().: double: {Convert.ToInt32(9.49)}");
            WriteLine($"Convert cast ToInt32().: double: {Convert.ToInt32(9.50)}");
        }
    }
}
