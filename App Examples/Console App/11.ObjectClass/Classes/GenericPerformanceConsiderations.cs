using System;
using System.Diagnostics;
using static System.Console;

public class GenericPerformanceConsiderations<T>
{
    public void Process(T value)
    {
        string s = value.ToString();
        // Write("Processing generic type: " + value);
    }
}