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
            // 1. �إ߮e��
            var container = new UnityContainer();

            //// 2. ���U�A�ȡB����

            //// Entity
            //var dbContext = new EShopContext();
            //// Repository
            //container.RegisterType<IRepository<Category>, IRepository<Category>>(
            //    new InjectionConstructor(dbContext));
            //// Service
            //container.RegisterType<ICategoryService, CategoryService>();


            //// 3. �}�l�`�J
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}