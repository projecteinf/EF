using System;
using System.Diagnostics;
using static System.Console;

public class PerformanceConsiderations
{
    // General method that accepts an Object type (may involve boxing)
    public void Process(object value)
    {
        // Write("Processing object: " + value);
    }

    // Type-specific method overload for int (avoids boxing)
    public void Process(int value)
    {
        string s = value.ToString();
        // Write("Processing int: " + value);
    }

    // Type-specific method overload for bool (avoids boxing)
    public void Process(bool value)
    {
        string s = value.ToString();
        // Write("Processing bool: " + value);
    }
}