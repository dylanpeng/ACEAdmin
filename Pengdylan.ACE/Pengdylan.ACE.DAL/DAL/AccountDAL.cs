using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pengdylan.ACE.Common.DALImplement;
using Pengdylan.ACE.Data;

namespace Pengdylan.ACE.DAL
{
    public class AccountDAL : IAccountDAL
    {
        public int Add(Data.Account account)
        {
            if (account == null)
                return -1;
            var context = new DataContext();
            context.Account.Add(account);
            context.SaveChanges();
            return account.ID;
        }

        public int ValidateAccount(string name, string passWord)
        {
            var context = new DataContext();
            var account = context.Account.Where(q => q.Name == name && q.Password == passWord && q.IsDelete == false).FirstOrDefault();
            return account != null ? account.ID : -1;
        }

        public bool IsAccountRegistered(string name)
        {
            var context = new DataContext();
            int count = context.Account.Count(q => q.Name == name && q.IsDelete == false);
            return count > 0 ? true : false;
        }
    }
}
