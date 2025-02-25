using System;
using System.Globalization;
using static System.Console;

public class Example0
{
   public static void Main()
   {
        WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
        WriteLine("CurrentUICulture is {0}", CultureInfo.CurrentUICulture.Name);
        WriteLine("En aquest moment a Catalunya: {0}", DateTime.Today);

        var englishCulture = new CultureInfo("en-EN");
        CultureInfo.CurrentCulture = englishCulture;
        CultureInfo.CurrentUICulture = englishCulture;
        WriteLine("En aquest moment a Anglaterra: {0}", DateTime.Today);
   }
}