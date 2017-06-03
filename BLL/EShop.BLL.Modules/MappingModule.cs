using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BLL.Modules
{
    public class MappingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mappings = Assembly.Load("EShop.BLL.Mappings");

            builder.RegisterAssemblyTypes(mappings)
                   .Where(i => i.Name.EndsWith("MappingProfile"))
                   .As(i => i.BaseType);

            base.Load(builder);
        }
    }
}
