namespace EF.InsertData
{
    class Program
    {
        public static void Main(string[] args)
        {
            var wallet = new Wallet
            {
                Id = 6,
                Holder = "Ahmed",
                Balance = 12000m
            };
            using (var context = new AppDbContext())
            {
                context.Wallets.Add(wallet);
                context.SaveChanges();
                foreach (var item in context.Wallets)
                    Console.WriteLine(item);
            }
        }
    }
}