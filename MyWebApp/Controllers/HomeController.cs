using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public bool GetCookie()
        {
            HttpCookie cookie = Request.Cookies["UC"];
            if (cookie != null)
            {
                return true;
            }
            else return false;
        }

        public ActionResult Index()
        {
            ViewBag.Cookie = GetCookie();
            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Cookie = GetCookie();
            return View();
        }
    }
}