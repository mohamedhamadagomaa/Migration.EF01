using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.EFRetriveSingleItem
{
    internal class AppDbContext : DbContext
    {
        // represnt the collection of all entities
        public DbSet<Wallet> Wallets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json")
                .Build();
            var constr = configuration.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }
    }
}
