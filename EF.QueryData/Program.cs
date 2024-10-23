namespace EF.QurtyData
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // retrieve all wallets with balance > 8000
                var wallet = context.Wallets.Where(x => x.Balance > 8000);
                // itartion on wallet IEnumarable
                foreach (var item in wallet)
                    Console.WriteLine(item);
            }
        }
    }
}