using Autofac;
using EShop.DAL.Interfaces;
using EShop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DAL.Modules
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // 註冊所有IRepository<>型別
            builder.RegisterGeneric(typeof(GenericRepository<>))
           .As(typeof(IRepository<>))
           .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
