using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Pengdylan.ACE.Data.Mapping;

namespace Pengdylan.ACE.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=MyContext")
        {

        }



        public DbSet<Account> Account { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Configurations.Add(new AccountEntityTypeConfiguration());
        }


    }
}
