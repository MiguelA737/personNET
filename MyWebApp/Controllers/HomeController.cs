using MyWebApp.Repositories.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(UserControl.VerifyUserStatus() != null) return Redirect("/MainPage/Index");
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
    }
}