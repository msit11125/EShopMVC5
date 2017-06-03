using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EShop.WebBack.Controllers.Factory
{
    public class ControllerFactory: DefaultControllerFactory
    {
        // tab1. ControllerFactory.cs : CreateController(RequestContext requestContext, string controllerName)

        // tab2. global.asax : ControllerBuilder.Current.SetControllerFactory(new ControllerFactory());

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Products")
            {
                // new 組合根 ...

                return null;
            }
            else
            {
                return null;
            }
        }


    }
}