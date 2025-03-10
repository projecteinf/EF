using System;
using System.Collections;
using System.Globalization;
using static System.Console;
using BoscComa.ADO;

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
                Uuid = CreateUUID(),
                Name = "Joan", 
                Email = "joan@gmail.com", 
                DateOfBirth = ConvertToDate("18/12/2000","ca-ES")
            };

            user.SetPassword("Patata1234");
            UserADO userADO = new UserADO(connection);
            userADO.Create(user);
        }

        public static DateTime ConvertToDate(string date,string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture);
            return DateTime.Parse(date, cultureInfo);

        }

        public static string CreateUUID() 
        {
            Guid myuuid = Guid.NewGuid();
            return myuuid.ToString();
        }
    }
}