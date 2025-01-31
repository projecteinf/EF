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


            double[] numExamples = new[] { 9.49, 9.50, 9.51, 10.49, 10.50, 10.51 };
            foreach (double numExample in numExamples)
            {
                if (numExample == 9.5) {
                    WriteLine($"{(int)numExample} és imparell s'arrodoneix el valor");
                }
                else {
                    if (numExample == 10.5) {
                        WriteLine($"{(int)numExample} és parell trunca el valor");
                    }
                }
                WriteLine($"{numExample} ToInt32: {Convert.ToInt32(numExample)}");
            }

            foreach (double numExample in numExamples)
            {
                WriteLine($"{numExample} valor arrodonit: {Math.Round(numExample, MidpointRounding.AwayFromZero)}"); // Arrodonir el valor si la part decimal és 0.5
            }
        }
    }
}
