using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.Web.Controllers
{
    public class AccountController : Controller
    {
        

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(string userid,string passward)
        {
            return View();
        }

    }
}