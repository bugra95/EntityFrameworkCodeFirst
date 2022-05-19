using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstOrnek2
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() 
        {
            Database.Connection.ConnectionString = "server=.; database=SecondDB; uid=sa; pwd=123";
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
