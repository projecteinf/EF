/// <summary>
///     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
/// </summary>


using Microsoft.EntityFrameworkCore;

namespace BoscComa.EF
{
    public class AppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get;set; }
    }

    protected override void OnConfiguring(DBContextOptionsBuilder options)
    {
        
    }
}