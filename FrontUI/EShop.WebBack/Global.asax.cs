using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EShop.WebBack
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            // |DataDirectory| C:\Users\msit11125\Desktop\Eshop\Domain\EShop.CodeFirst
            //                 C:\Users\USER\Desktop\Eshop\Domain\EShop.CodeFirst
            string dbPath = Path.Combine(HttpRuntime.AppDomainAppPath.Replace(@"\FrontUI\EShop.WebBack", ""), @"Domain\EShop.CodeFirst");
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);



            //Unity MVC5 初始化
            //UnityConfig.RegisterComponents();

            //Autofac MVC5 初始化
            AutofacConfig.Initialize();
            AutoMapperConfig.Configure();

            #region Global
            AreaRegistration.RegisterAllAreas();
            // Manually installed WebAPI 2.2 after making an MVC project.
            GlobalConfiguration.Configure(WebApiConfig.Register);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            #endregion

        }
    }
}
