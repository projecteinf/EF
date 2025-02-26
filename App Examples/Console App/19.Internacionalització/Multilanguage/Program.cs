using System;
using System.Globalization;
using System.Resources;
using System.Reflection;
using static System.Console;

class Program
{
    static void Main()
    {
        string currentCultureName = CultureInfo.CurrentUICulture.Name;
        WriteLine("Cultura per defecte: {0}",currentCultureName);

        string assemblyName = Assembly.GetExecutingAssembly().GetName().Name!;
        string resourceName = $"{assemblyName}.Resources.Resources";
        ResourceManager rm = new ResourceManager(resourceName, Assembly.GetExecutingAssembly());

        WriteLine(rm.GetString("HelloMessage", CultureInfo.CurrentUICulture));
        WriteLine(rm.GetString("GoodbyeMessage", CultureInfo.CurrentUICulture));

        string newCulture = "ca-ES";
        if (currentCultureName == "ca-ES") {
            newCulture="en-GB";
        }

        CultureInfo culture = new CultureInfo(newCulture); 
        
        WriteLine(rm.GetString("HelloMessage", culture));
        WriteLine(rm.GetString("GoodbyeMessage", culture));
    }
}
