using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using EShop.DAL.Repository;

namespace EShop.WebBack
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // 1. 建立容器
            var container = new UnityContainer();

            //// 2. 註冊服務、物件

            //// Entity
            //var dbContext = new EShopContext();
            //// Repository
            //container.RegisterType<IRepository<Category>, IRepository<Category>>(
            //    new InjectionConstructor(dbContext));
            //// Service
            //container.RegisterType<ICategoryService, CategoryService>();


            //// 3. 開始注入
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}