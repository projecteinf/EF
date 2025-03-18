/// <summary>
///     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
///     dotnet add package Microsoft.EntityFrameworkCore.Design
/// </summary>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BoscComa.Connexio;
namespace BoscComa.EF 
{
    public class Program {
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(ConnectToDB()))
                .BuildServiceProvider();

                using var context = serviceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
        }

        private static string ConnectToDB() 
        {
            string path=@"/home/projecteinf/Projectes/2025/EF/App Examples/Console App/20.DB/EF/Config";
            string fileName=@"connction.enc";
            return StringConnection.GetDecrypt(path,fileName);
        }
    }
}