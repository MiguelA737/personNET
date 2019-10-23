using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;
using MyWebApp.Repositories.Authentication;

namespace MyWebApp.Controllers
{
    public class UserSignupController : Controller
    {
        private personNETEntities db = new personNETEntities();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,Name,E_mail,Pass,DirProfilePhoto,BirthDate,LastAccess,HasPremiumAccess")] TB_User tB_User)
        {
            if (db.TB_User.ToList().Find(x => x.E_mail.Equals("" + tB_User.E_mail.GetHashCode())) == null)
            {
                if (ModelState.IsValid)
                {
                    tB_User.Pass = "" + tB_User.Pass.GetHashCode();
                    tB_User.E_mail = "" + tB_User.E_mail.GetHashCode();
                    db.TB_User.Add(tB_User);
                    db.SaveChanges();
                    CookieControl.CreateCookie(tB_User, false);
                    return Redirect("../MainPage/Index");
                }
            }
            return View(tB_User);
        }

    }
}
