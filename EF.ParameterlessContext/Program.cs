using EF.InternalConfiguration.Data;

namespace EF.InternalConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var wallet in context.Wallets)
                    Console.WriteLine(wallet.Holder);
            }
        }
    }
}
