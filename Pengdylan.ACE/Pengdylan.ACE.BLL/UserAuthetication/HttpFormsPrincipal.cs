using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Pengdylan.ACE.BLL
{
    /// <summary>
    /// 通用的用户实体
    /// </summary>
    /// <typeparam name="TUserData"></typeparam>
    public class HttpFormsPrincipal<TUserData> : IPrincipal where TUserData:class, new()
    {
        //当前用户实例
        public IIdentity Identity { get; private set; }

        //用户数据
        public TUserData UserData { get; private set; }

        public HttpFormsPrincipal(FormsAuthenticationTicket ticket, TUserData userData)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            if (userData == null)
                throw new ArgumentNullException("UserData");

            Identity = new FormsIdentity(ticket);
            UserData = userData;
        }

        //角色验证
        public bool IsInRole(string role)
        {
            var userData = UserData as HttpUserDataPrincipal;
            if (userData == null)
                throw new NotImplementedException();
            return userData.IsInRole(role);

        }

    }
}
