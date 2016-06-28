using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Pengdylan.ACE.Common;
using Pengdylan.ACE.DAL.DALImplement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pengdylan.ACE.Data;

namespace Pengdylan.ACE.BLL
{
    public class AccountBLL
    {
        public static bool Add(string name, string passWord)
        {
            var account = new Data.Account()
            {
                Name = name,
                Password = passWord,
                IsDelete = false,
                CreatedTime = DateTime.Now
            };
            var iocRepository = UnityContainerRepository.getInstance();
            var accountDAL = iocRepository.container.Resolve<IAccountDAL>();
            return accountDAL.Add(account);
        }
    }
}
