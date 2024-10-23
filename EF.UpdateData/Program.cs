namespace EF.UpdateData
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // update wallet (id = 4) increase balance by 1000

                // get 
                var wallet = context.Wallets.Single(x => x.Id == 4);
                wallet.Balance += 1000;
                context.SaveChanges();

            }
        }
    }
}