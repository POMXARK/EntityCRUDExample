using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCRUDExample
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string developBase = "C:\\Users\\User\\source\\repos\\\\EntityCRUDExample\\\\EntityCRUDExample\\products.db";

            optionsBuilder.UseSqlite("Data Source=" + developBase);

            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
