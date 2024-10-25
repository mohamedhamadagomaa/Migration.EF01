using EF.UsingDependencyInjection.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.UsingDependencyInjection.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
