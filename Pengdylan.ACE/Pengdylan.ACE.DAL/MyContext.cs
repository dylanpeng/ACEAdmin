using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Pengdylan.ACE.Data;

namespace Pengdylan.ACE.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyContext")
        {

        }



        public DbSet<Account> Account { get; set; }
    }
}
