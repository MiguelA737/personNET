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
    public class Core_Access_DenialController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: Core_Access_Denial
        public ActionResult Index()
        {
            var core_Access_Denial = db.Core_Access_Denial.Include(c => c.TB_Core).Include(c => c.TB_User);
            return View(core_Access_Denial.ToList());
        }

        // GET: Core_Access_Denial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Core_Access_Denial core_Access_Denial = db.Core_Access_Denial.Find(id);
            if (core_Access_Denial == null)
            {
                return HttpNotFound();
            }
            return View(core_Access_Denial);
        }

        // GET: Core_Access_Denial/Create
        public ActionResult Create()
        {
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name");
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name");
            return View();
        }

        // POST: Core_Access_Denial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAccessDenial,IdUser,IdCore")] Core_Access_Denial core_Access_Denial)
        {
            if (ModelState.IsValid)
            {
                db.Core_Access_Denial.Add(core_Access_Denial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", core_Access_Denial.IdCore);
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", core_Access_Denial.IdUser);
            return View(core_Access_Denial);
        }

        // GET: Core_Access_Denial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Core_Access_Denial core_Access_Denial = db.Core_Access_Denial.Find(id);
            if (core_Access_Denial == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", core_Access_Denial.IdCore);
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", core_Access_Denial.IdUser);
            return View(core_Access_Denial);
        }

        // POST: Core_Access_Denial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAccessDenial,IdUser,IdCore")] Core_Access_Denial core_Access_Denial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(core_Access_Denial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", core_Access_Denial.IdCore);
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", core_Access_Denial.IdUser);
            return View(core_Access_Denial);
        }

        // GET: Core_Access_Denial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Core_Access_Denial core_Access_Denial = db.Core_Access_Denial.Find(id);
            if (core_Access_Denial == null)
            {
                return HttpNotFound();
            }
            return View(core_Access_Denial);
        }

        // POST: Core_Access_Denial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Core_Access_Denial core_Access_Denial = db.Core_Access_Denial.Find(id);
            db.Core_Access_Denial.Remove(core_Access_Denial);
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
