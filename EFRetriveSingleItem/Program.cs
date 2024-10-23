namespace EF.EFRetriveSingleItem
{
    class Program
    {
        public static void Main(string[] args)
        {
            var itemId = 2;
            var itemName = "mohammed";
            using (var context = new AppDbContext())
            {
                var item = context.Wallets.FirstOrDefault(x => x.Id == itemId);
                var q1 = context.Wallets.FirstOrDefault(x => x.Holder == itemName);

                Console.WriteLine(q1);
            }
        }

    }
}