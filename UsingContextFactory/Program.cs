using EF.UsingContextFactory.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.UsingContextFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            var constr = configuration.GetSection("constr").Value;
            var services = new ServiceCollection();
            services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(constr));
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var contextFactory = serviceProvider.GetService<IDbContextFactory<AppDbContext>>();
            using (var context = contextFactory!.CreateDbContext())
            {
                foreach (var wallet in context!.Wallets)
                    Console.WriteLine(wallet.Holder);
            }
        }
    }
}
