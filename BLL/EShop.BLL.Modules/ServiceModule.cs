using Autofac;
using EShop.BLL.Interfaces;
using EShop.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //// 註冊方法 1

            //builder.RegisterType<CategoryService>().As<ICategoryService>();



            //// 註冊方法 2


            //載入命名空間
            var asmb = Assembly.Load("EShop.BLL.Service");
            // /*或是*/ var asmb = Assembly.GetExecutingAssembly(); // 獲得全部的Assembly


            //搜尋命名空間結尾為Service的類別 做註冊
            builder.RegisterAssemblyTypes(asmb)
            .Where(t => t.Name.EndsWith("Service")) // 指定型別篩選條件
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
