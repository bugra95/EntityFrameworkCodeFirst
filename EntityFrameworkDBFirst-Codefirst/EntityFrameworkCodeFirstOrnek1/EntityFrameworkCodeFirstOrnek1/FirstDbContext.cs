using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstOrnek1
{
    public class FirstDbContext : DbContext
    {
        public FirstDbContext()
        {
            Database.Connection.ConnectionString = "server=.; database=FirstDB; uid=sa; pwd=123";
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
