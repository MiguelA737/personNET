using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class MainPageController : RestrictedController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}