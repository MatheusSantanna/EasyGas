using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyGas.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=EasyGas;Username=postgres;Password=Matheus100@");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}