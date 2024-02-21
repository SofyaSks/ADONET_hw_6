using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletLib
{
    public class WalletDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\.;Initial Catalog=Wallet;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=False");
        }
    }
}
