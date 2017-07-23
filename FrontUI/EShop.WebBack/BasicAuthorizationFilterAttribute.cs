using EShop.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace EShop.WebBack
{
    //此驗證元件 
    //只能供給 WebApi 使用
    public class BasicAuthorizationFilterAttribute : AuthorizationFilterAttribute
    {
        //帶入 Token    Bearer Admin:0000
        //檢查登入狀況
        //Principal 會記住 username

        IEmployeeService _employee;
        public BasicAuthorizationFilterAttribute()
        {
            // 注入方法
            _employee = DependencyResolver.Current.GetService<IEmployeeService>();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodeAuthenticationToken.Split(':');
                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];

                //如果登入成功
                if (_employee.Login(username, password))
                {
                    //這並不會存到cookie
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized,"Username or password error.");
                }
            }

        }
    }
}