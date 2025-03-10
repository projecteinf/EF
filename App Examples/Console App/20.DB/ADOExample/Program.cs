using System;
using System.Collections;
using static System.Console;
using BoscComa.ADO;
using BoscComa.Helper;

namespace BoscComa.AppERP
{
    public class Program 
    {
        public static void Main() 
        {
            string path=@"/home/projecteinf/Projectes/2025/EF/App Examples/Console App/20.DB/ADO/Config";
            string fileName=@"connction.enc";
            Connection.Inicialitzar(path, fileName);
            Connection connection = Connection.ConnectionDB;
            
            User user = new User
            {
                Uuid = Utils.CreateUUID(),
                Name = "Joan", 
                Email = "joan@gmail.com", 
                DateOfBirth = Utils.ConvertToDate("18/12/2000","ca-ES")
            };

            user.SetPassword("Patata1234");
            UserADO userADO = new UserADO(connection);
            userADO.Create(user);
        }

        
    }
}