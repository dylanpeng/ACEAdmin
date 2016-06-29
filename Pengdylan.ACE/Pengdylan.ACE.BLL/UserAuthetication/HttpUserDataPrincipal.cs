using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Web.Security;
using System.Web.Script.Serialization;

namespace Pengdylan.ACE.BLL
{
    /// <summary>
    /// 存放数据的用户实体
    /// </summary>
    public class HttpUserDataPrincipal : IPrincipal
    {
        //用户ID
        public int UserId { get; set; }

        //用户名
        public string UserName { get; set; }
        //用户角色
        public List<int> RoleIds { get; set; }

        //当使用Authorize特性时，会调用该方法验证角色
        public bool IsInRole(string role)
        {
            return true;
        }

        [ScriptIgnore]
        public IIdentity Identity { get { throw new NotImplementedException(); } }
    }
}
