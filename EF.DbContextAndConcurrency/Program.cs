using EF.DbContextAndConcurrency.Data;
using EF.DbContextAndConcurrency.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF.DbContextAndConcurrency
{
    internal class Program
    {
        static AppDbContext context;
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            var constr = configuration.GetSection("constr").Value;
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(constr));
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            context = serviceProvider.GetRequiredService<AppDbContext>();
            //create a Task built in  class to execute asyncronous operations
            var tasks = new[]
            {
                Task.Factory.StartNew(() => Jop1()),
                Task.Factory.StartNew(() => Jop2())
            };

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                Console.WriteLine("Jop1 And Jop2 executed Concurrently");
            });
            //Console.WriteLine("Hello");
            Console.ReadKey();
        }

        static async Task Jop1()
        {

            var w1 = new Wallet { Id = 18, Holder = "Mahmmoud", Balance = 15000m };
            context.Wallets.Add(w1);
            await context.SaveChangesAsync();
        }
        static async Task Jop2()
        {

            var w2 = new Wallet { Id = 19, Holder = "Reema", Balance = 15000m };
            context.Wallets.Add(w2);
            await context.SaveChangesAsync();
        }
    }
}
