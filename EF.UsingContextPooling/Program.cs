using EF.UsingDbContextPooling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.UsingDbContextPooling
{
    internal class Program
    {
        static AppDbContext context;
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            var constr = configuration.GetSection("constr").Value;
            var services = new ServiceCollection();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(constr));
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (var context = serviceProvider.GetService<AppDbContext>())
            {
                foreach (var wallet in context!.Wallets)
                    Console.WriteLine(wallet);
            }
            Console.ReadKey();
        }
    }
}

