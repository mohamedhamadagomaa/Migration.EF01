using EF.DbContextLifeTime.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.DbContextLifeTime.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
