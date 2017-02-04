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
    ////依赖注入实例
    //public class testBLL1
    //{
    //    [Dependency]
    //    public IAccountDAL dal { get; set; }
    //    public void add()
    //    {
    //        var account = new Data.Account()
    //        {
    //            Name = "a",
    //            Password = "abc",
    //            IsDelete = false,
    //            CreatedTime = DateTime.Now
    //        };
    //        dal.Add(account);
    //    }
    //}

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
                //testBLL1 test = UnityContainerRepository.GetInstanceDAL<testBLL1>();
                //test.add();
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
