using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Pengdylan.ACE.Common
{
    public class UnityContainerRepository
    {
        //仓库
        private static UnityContainerRepository instance;

        //ioc容器
        public IUnityContainer container;


        public static UnityContainerRepository getInstance()
        {
            if (instance == null)
            {
                instance = new UnityContainerRepository()
                {
                    container = new UnityContainer().LoadConfiguration((UnityConfigurationSection)ConfigurationManager.GetSection("unity"), "MyContainer")
                };
            }
            return instance;
        }

        public static T GetInstanceDAL<T>()
        {
            return getInstance().container.Resolve<T>();
        }
    }
}
