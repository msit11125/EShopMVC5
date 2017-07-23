using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace EShop.WebBack.Api
{
    public class AccountTestController : ApiController
    {
        //登入用Web Api 做filter自訂屬性實現
        [BasicAuthorizationFilterAttribute]
        public IEnumerable<string> Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            return new string[] { username };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            return "value";
        }
    }
}
