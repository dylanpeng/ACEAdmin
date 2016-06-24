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


        #region 实体对象

        public DbSet<Account> Account { get; set; }

        
        #endregion


        #region mapping配置
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Configurations.Add(new AccountEntityTypeConfiguration());
        }
        #endregion

    }
}
