using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWEB.Controllers
{
    public class HomeController : Controller
    {

        public Boolean session()
        {
            if (Request.Cookies["authentication"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult Index()
        {
            if (session())
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
       }

      
    }
}