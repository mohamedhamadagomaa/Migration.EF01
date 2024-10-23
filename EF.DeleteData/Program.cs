namespace EF.DeleteData
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var itemId = 3;
                var wallet = context.Wallets.Single(x => x.Id == itemId);
                context.Wallets.Remove(wallet);
                context.SaveChanges();
            }
        }
    }
}