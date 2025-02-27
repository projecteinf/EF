using System;
using static System.Console;
using BoscComa.ADO;

namespace BoscComa.AppERP
{
    public class Program 
    {
        public static void Main() 
        {
            
            string password = Convert.ToBase64String(User.GetHashPassword("Password"));
            WriteLine($"{password}");
        }
    }
}