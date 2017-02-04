using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Pengdylan.ACE.Common;
using Pengdylan.ACE.Common.DALImplement;
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
        public static int Add(string name, string passWord)
        {
            if (!IsAccountRegistered(name))
            {
                var account = new Data.Account()
                {
                    Name = name,
                    Password = passWord,
                    IsDelete = false,
                    CreatedTime = DateTime.Now
                };
                //var iocRepository = UnityContainerRepository.getInstance();
                //var accountDAL = iocRepository.container.Resolve<IAccountDAL>();
                var accountDAL = UnityContainerRepository.GetInstanceDAL<IAccountDAL>();
                return accountDAL.Add(account);
            }
            else
                return -1;
        }

        public static int ValidateAccount(string name, string passWord)
        {
            return UnityContainerRepository.getInstance().container.Resolve<IAccountDAL>().ValidateAccount(name, passWord);
        }
        public static bool IsAccountRegistered(string name)
        {
            return false;
            return UnityContainerRepository.getInstance().container.Resolve<IAccountDAL>().IsAccountRegistered(name);
        }

    }
}
