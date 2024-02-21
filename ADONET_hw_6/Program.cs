using WalletLib;

using WalletDbContext db = new();

Console.WriteLine("\t\tРасходы в хронологическом порядке\n");

IReadOnlyCollection<Wallet> wallets = db.Wallets
    .OrderBy(wallet => wallet.Date)
    .ToList();

foreach (var wallet in wallets)
{
    Console.WriteLine(wallet);
}

Console.WriteLine("\n\t\tВсе расходы на продукты\n");

wallets = db.Wallets
    .Where(Wallet => Wallet.What == "Продукты")
    .OrderBy(Wallet => Wallet.Date)
    .ToList();

foreach (var wallet in wallets)
{
    Console.WriteLine(wallet);
}

Console.WriteLine("\n\t\tСумма всех расходов\n");

var sum = db.Wallets.Sum(Wallet => Wallet.Amount);
Console.WriteLine(sum);

Console.WriteLine("\n\t\tСумма расходов за май 2023\n");

sum = db.Wallets
    .Where(wallet=> wallet.Date.Year == 2023 && wallet.Date.Month == 5)
    .Sum(Wallet => Wallet.Amount);

Console.WriteLine(sum);

Console.WriteLine("\n\t\tСумма расходов по каждому виду трат\n");

var groupWallets = db.Wallets
    .GroupBy(Wallet => Wallet.What)
    .Select(group => new
    {
        What = group.Key,
        MoneySum = group.Sum(wallet=>wallet.Amount)
    });

foreach (var wallet in groupWallets)
{
    Console.WriteLine(wallet);
}