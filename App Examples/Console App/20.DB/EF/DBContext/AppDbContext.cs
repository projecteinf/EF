/// <summary>
///     dotnet add package Microsoft.EntityFrameworkCore.SqlServer
/// </summary>


using Microsoft.EntityFrameworkCore;

namespace BoscComa.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        
    }
}