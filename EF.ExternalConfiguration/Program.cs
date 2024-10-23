using EF.ExternalConfiguration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.ExternalConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            var constr = configuration.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();
            optionBuilder.UseSqlServer(constr);
            var options = optionBuilder.Options;

            using (var context = new AppDbContext(options))
            {
                foreach (var wallet in context.Wallets)
                    Console.WriteLine(wallet);
            }
        }
    }
}
