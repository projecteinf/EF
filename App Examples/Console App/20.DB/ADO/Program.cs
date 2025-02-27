using System;
using System.Collections;
using static System.Console;
using BoscComa.Helper;
using BoscComa.ADO;

namespace BoscComa.AppERP
{
    public class Program 
    {
        
        public static void Main() 
        {
            List <string> passwordClear = new List<string>();
            List <User> users = new List<User>();
            for(short i=0;i<10;i++) 
            {
                users.Add(Program.CreateRandomUser(passwordClear));
            }
            short index = 0;
            foreach (User user in users)
            {
                WriteLine(user.ToString());
                WriteLine($"Password clear: {passwordClear[index++]}");
            }
            
            Program.VerificarPassword(users[0],passwordClear[0]);
            Program.VerificarPassword(users[0],passwordClear[1]);
        }

        public static User CreateRandomUser(List<string> passwordClear) {
            User user = new User();
            user.Name = RandomGenerator.GenerateRandomString(6);
            string password = RandomGenerator.GenerateRandomString(8);
            user.SetPassword(password);
            passwordClear.Add(password);
            return user;
        }

        public static void VerificarPassword(User user,string password)
        {
            string result = user.VerifyPassword(password) ? "Password correcte" : "Password incorrecte";
            WriteLine(result);
        }
    }
}