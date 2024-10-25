using EF.DbContextLifeTime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.DbContextLifeTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            var constr = configuration.GetSection("constr").Value;
            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(constr);
            var option = optionBuilder.Options;
            using (var context = new AppDbContext(option))
            {
                // THere are two wallets were added 
                //var w1 = new Wallet { Id = 16, Holder = "Jassem", Balance = 1000m };
                //context.Wallets.Add(w1);
                //var w2 = new Wallet { Id = 17, Holder = "Rania", Balance = 15000m };
                //context.Wallets.Add(w2);
                //context.SaveChanges();
            }
        }
    }
}
