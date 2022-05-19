using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirstMapping
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "server=.; database=MappingDB; uid=sa; pwd=123";
        }


        public DbSet<AppUser> Users { get; set; }   // Entity Splitting
        public DbSet<Product> Products { get; set; }    // Conditional Mapping
        public DbSet<Category> Categories { get; set; } // Conditional Mapping
        public DbSet<Teacher> Teachers { get; set; }    // Many-to-Many
        public DbSet<Student> Students { get; set; }    // Many-to-Many
        public DbSet<Employee> Employees { get; set; }  // Table Splitting
        public DbSet<CompositeKeyTable> CompositeKeyTable { get; set; } // Composite Key


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tablo isimlerinin otomatik olarak çoğul olmasını engeller...
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Table Splitting...
            modelBuilder.Entity<Employee>().HasKey(k => k.EmployeeID).ToTable("Employees");
            modelBuilder.Entity<EmployeeContactDetail>().HasKey(k => k.EmployeeID).ToTable("Employees");
            modelBuilder.Entity<Employee>().HasRequired(x => x.EmployeeContactDetail).WithRequiredPrincipal(y => y.Employee);

            // Entity Splitting...
            modelBuilder.Entity<AppUser>().Map(map =>
            {
                map.Properties(u => new
                {
                    u.ID,
                    u.UserName,
                    u.Password
                });
                map.ToTable("UserAccountInfo");
            }).Map(map =>
            {
                map.Properties(u => new
                {
                    u.ID,
                    u.ContactNumber,
                    u.Address
                });
                map.ToTable("UserContactDetail");
            });

            // Contational Mapping...
            modelBuilder.Entity<Product>().Map(m => m.Requires("IsOnSale").HasValue(true)).Ignore(m => m.IsOnSale);

            // Many-to-Many Relation...
            modelBuilder.Entity<Teacher>().HasMany(t => t.Students).WithMany(t => t.Teachers).Map(map =>
            {
                map.ToTable("TeacherStudent");
                map.MapLeftKey("TeacherID");
                map.MapRightKey("StudentID");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
