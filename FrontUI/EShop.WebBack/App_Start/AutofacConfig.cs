using Autofac;
using Autofac.Integration.Mvc;
using EShop.BLL.Modules;
using EShop.DAL.Modules;
using EShop.DAL.Interfaces;
using EShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Configuration;

namespace EShop.WebBack
{
    public class AutofacConfig
    {
        public static void Initialize()
        {
            //// 1. 建立者
            var builder = new ContainerBuilder();

            //// 2. 註冊服務、物件

            // MVC
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            // DbContext *** 附註:有Repository時，Ui層就要加入參考
            builder.RegisterType(typeof(EShopContext)).As(typeof(DbContext)).InstancePerLifetimeScope();

            #region 這邊不知為何不能使用連線產生實體 DbContext 暫時不使用
            //string connectStr = ConfigurationManager.ConnectionStrings["EShopModel"].ConnectionString;

            //builder.RegisterType<DbContextFactory>()
            //    .WithParameter("connectionString", connectStr)
            //    .As<IDbContextFactory>()
            //    .InstancePerLifetimeScope();
            #endregion


            // UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            // Repository
            builder.RegisterModule<RepositoryModule>(); //等同(new RepositoryModule());
            // Service
            builder.RegisterModule<ServiceModule>();  //等同(new ServiceModule());

            builder.RegisterFilterProvider();




            //註冊 Auto Mapping
            builder.RegisterModule<MappingModule>();


            //// 3. 建立容器
            var container = builder.Build();

            //// 4. 開始解析
            using (var scoper = container.BeginLifetimeScope())
            {
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
        }
    }
}