using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Pengdylan.ACE.BLL
{
    /// <summary>
    /// 身份验证类
    /// </summary>
    /// <typeparam name="TUserData"></typeparam>
    public class HttpFormsAuthentication<TUserData> where TUserData : class, new()
    {
        //Cookie保存时间
        private const int CookieSaveDays = 14;

        //用户登录成功时设置Cookie
        public static void SetAuthCookie(string userName, TUserData userData, bool remembeMe)
        {
            if (userData == null)
                throw new ArgumentNullException("userData");

            var data = (new JavaScriptSerializer()).Serialize(userData);

            //创建ticket
            var ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddDays(CookieSaveDays), remembeMe, data);

            //加密ticket
            var cookieValue = FormsAuthentication.Encrypt(ticket);

            //创建Cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Domain = FormsAuthentication.CookieDomain,
                Path = FormsAuthentication.FormsCookiePath
            };
            if (remembeMe)
                cookie.Expires = DateTime.Now.AddDays(CookieSaveDays);

            //写入Cookie
            HttpContext.Current.Response.Cookies.Remove(cookie.Name);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        //从Request中解析出Tickit,UserData
        public static HttpFormsPrincipal<TUserData> TryParsePrincipal(HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            //1.读登录Cookie
            var cookie = request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrEmpty(cookie.Value))
                return null;

            try
            {
                //2.解密Cookie值，获取FormsAuthenticationTicket对象
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket != null && !string.IsNullOrEmpty(ticket.UserData))
                {
                    var userData = (new JavaScriptSerializer()).Deserialize<TUserData>(ticket.UserData);
                    if (userData != null)
                    {
                        return new HttpFormsPrincipal<TUserData>(ticket, userData);
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                //有异常不抛出，防止攻击者试探
                return null;
            }
        }
    }
}
