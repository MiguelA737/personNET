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
    public class TB_AdminController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Admin
        public ActionResult Index()
        {
            return View(db.TB_Admin.ToList());
        }

        // GET: TB_Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Admin tB_Admin = db.TB_Admin.Find(id);
            if (tB_Admin == null)
            {
                return HttpNotFound();
            }
            return View(tB_Admin);
        }

        // GET: TB_Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdmin,Name,E_mail,Pass,CurrentStatus,LastAccess")] TB_Admin tB_Admin)
        {
            if (ModelState.IsValid)
            {
                db.TB_Admin.Add(tB_Admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Admin);
        }

        // GET: TB_Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Admin tB_Admin = db.TB_Admin.Find(id);
            if (tB_Admin == null)
            {
                return HttpNotFound();
            }
            return View(tB_Admin);
        }

        // POST: TB_Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdmin,Name,E_mail,Pass,CurrentStatus,LastAccess")] TB_Admin tB_Admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Admin);
        }

        // GET: TB_Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Admin tB_Admin = db.TB_Admin.Find(id);
            if (tB_Admin == null)
            {
                return HttpNotFound();
            }
            return View(tB_Admin);
        }

        // POST: TB_Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Admin tB_Admin = db.TB_Admin.Find(id);
            db.TB_Admin.Remove(tB_Admin);
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
