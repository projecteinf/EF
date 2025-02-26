using System;
using Multilanguage.Helper;
using static System.Console;

class Program
{
    static void Main()
    {
        WriteLine(AppResources.GetString("HelloMessage", "ca-ES"));
        WriteLine(AppResources.GetString("GoodbyeMessage", "ca-ES"));       
        WriteLine(AppResources.GetString("HelloMessage", "en-GB"));
        WriteLine(AppResources.GetString("GoodbyeMessage", "en-GB"));
    }
}
