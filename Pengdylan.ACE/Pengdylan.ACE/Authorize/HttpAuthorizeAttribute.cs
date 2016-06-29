using Pengdylan.ACE.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pengdylan.ACE
{
    //验证角色和用户名的类
    public class HttpAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.User as HttpFormsPrincipal<HttpUserDataPrincipal>;
            if (user != null)
                return user.IsInRole(Roles);
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //验证不通过，直接跳转到相应页面，注意：如果不是哟娜那个以下跳转，则会继续执行Action方法
            filterContext.Result = new RedirectResult("http://pengdylan.admin.com/Account/Login");
        }
    }
}