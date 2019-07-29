using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebJoKenApi.Model;

namespace WebJoKenApi.Repository.Context
{
    public class ContextDb :DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options)
          : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\LocalDataBase;Initial Catalog=JokenPo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        public DbSet<Player> PlayerDB { get; set; }
    }
}
