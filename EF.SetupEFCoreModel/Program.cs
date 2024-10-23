using Microsoft.Extensions.Configuration;

namespace EF.SetupEFCoreModel
{
    class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            var constr = configuration.GetSection("constr").Value;
            Console.WriteLine(constr);
        }

    }
}