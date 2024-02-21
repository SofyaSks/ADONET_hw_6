namespace WalletLib
{
    public class Wallet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount {  get; set; }
        public string? What { get; set; }

        public ICollection<Wallet> Purchases { get; set; } = new List<Wallet>();

        public override string ToString()
        {
            return $"{What} \t {Amount,20} \t {Date.ToString("dd-MM-yyyy")}";
        }
    }
}
