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

namespace Pengdylan.ACE.BLL
{
    public class AccountBLL
    {
        public static bool Add()
        {
            var iocRepository = UnityContainerRepository.getInstance();
            var accountDAL = iocRepository.container.Resolve<IAccountDAL>();
            return accountDAL.Add();
        }
    }
}
