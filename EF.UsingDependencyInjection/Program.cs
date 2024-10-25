using EF.UsingDependencyInjection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.UsingDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            var constr = configuration.GetSection("constr").Value;
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(constr));
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                foreach (var wallet in context!.Wallets)
                    Console.WriteLine(wallet.Holder);
            }
        }
    }
}
