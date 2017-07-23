using EShop.BLL.Interfaces;
using System.Web.Mvc;
using System;
using System.Web;

namespace EShop.WebBack
{
    public class BasicAuthorizeAttribute : AuthorizeAttribute
    {
        private const string _securityToken = "token";
        IEmployeeService _employee;
        public BasicAuthorizeAttribute()
        {
            // 注入方法
            _employee = DependencyResolver.Current.GetService<IEmployeeService>();
        }

       
    }

}