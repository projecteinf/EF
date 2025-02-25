using System;
using System.Globalization;
using static System.Console;

public class Example0
{
   public static void Main()
   {
      // Display the name of the current culture.
      WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
      WriteLine("CurrentUICulture is {0}", CultureInfo.CurrentUICulture.Name);
   }
}