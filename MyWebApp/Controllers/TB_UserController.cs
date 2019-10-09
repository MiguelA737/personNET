using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class TB_UserController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_User
        public ActionResult Index()
        {
            return View(db.TB_User.ToList());
        }

        // GET: TB_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_User tB_User = db.TB_User.Find(id);
            if (tB_User == null)
            {
                return HttpNotFound();
            }
            return View(tB_User);
        }

        // GET: TB_User/Create
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
                    return RedirectPermanent("../Home/Index");
                }
            }
            return View(tB_User);
        }

        // GET: TB_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_User tB_User = db.TB_User.Find(id);
            if (tB_User == null)
            {
                return HttpNotFound();
            }
            return View(tB_User);
        }

        // POST: TB_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,Name,E_mail,Pass,DirProfilePhoto,BirthDate,LastAccess,HasPremiumAccess")] TB_User tB_User)
        {
            if (ModelState.IsValid)
            {
                tB_User.Pass = "" + tB_User.Pass.GetHashCode();
                tB_User.E_mail = "" + tB_User.E_mail.GetHashCode();
                db.Entry(tB_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_User);

        }

        // GET: TB_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_User tB_User = db.TB_User.Find(id);
            if (tB_User == null)
            {
                return HttpNotFound();
            }
            return View(tB_User);
        }

        // POST: TB_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_User tB_User = db.TB_User.Find(id);
            db.TB_User.Remove(tB_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
