using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengdylan.ACE.DAL
{
    public static class TestDAL
    {
        public static bool Add()
        {
            var context = new MyContext();
            context.Account.Add(new Data.Account() { Name = "admin", Password = "123456" });
            context.SaveChanges();
            bool result = false;
            return result;
        }
    }
}
