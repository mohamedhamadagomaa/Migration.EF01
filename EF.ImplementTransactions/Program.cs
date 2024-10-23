namespace EF.ImplementTransactions
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    // transfer $500 from wallet id = 6 to id = 5
                    var fromWallet = context.Wallets.Single(x => x.Id == 6);
                    var toWallet = context.Wallets.Single(x => x.Id == 5);
                    var amountToTrnsfer = 500m;

                    // operation #1 withdraw 500 from wallet id = 6
                    fromWallet.Balance -= amountToTrnsfer;
                    context.SaveChanges();
                    toWallet.Balance += amountToTrnsfer;
                    context.SaveChanges();
                    // To Commit All operations
                    transaction.Commit();
                }
            }
        }
    }
}