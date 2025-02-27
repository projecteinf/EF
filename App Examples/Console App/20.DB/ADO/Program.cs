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
            for(int i=0;i<10;i++) 
            {
                users.Add(createRandomUser(passwordClear));
            }
            short index = 0;
            foreach (User user in users)
            {
                WriteLine(user.ToString());
                WriteLine($"Password clear: {passwordClear[index++]}");
            }
        }

        public static User createRandomUser(List<string> passwordClear) {
            User user = new User();
            user.Name = RandomGenerator.GenerateRandomString(6);
            string password = RandomGenerator.GenerateRandomString(8);
            user.SetPassword(password);
            passwordClear.Add(password);
            return user;
        }
    }
}