using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Pengdylan.ACE.DAL.DALImplement;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pengdylan.ACE.BLL
{
    public static class AccountBLL
    {
        public static bool Add()
        {
            IUnityContainer container = new UnityContainer();//获取指定名称的配置节  
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            container.LoadConfiguration(section, "MyContainer");
            var accountDAL = container.Resolve<IAccountDAL>();
            return accountDAL.Add();
        }
    }
}
