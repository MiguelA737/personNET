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
    public class TB_CoreController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Core
        public ActionResult Index()
        {
            var tB_Core = db.TB_Core.Include(t => t.TB_User);
            return View(tB_Core.ToList());
        }

        // GET: TB_Core/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Core tB_Core = db.TB_Core.Find(id);
            if (tB_Core == null)
            {
                return HttpNotFound();
            }
            return View(tB_Core);
        }

        // GET: TB_Core/Create
        public ActionResult Create()
        {
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name");
            return View();
        }

        // POST: TB_Core/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCore,Name,Description,IdUser")] TB_Core tB_Core)
        {
            if (ModelState.IsValid)
            {
                db.TB_Core.Add(tB_Core);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", tB_Core.IdUser);
            return View(tB_Core);
        }

        // GET: TB_Core/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Core tB_Core = db.TB_Core.Find(id);
            if (tB_Core == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", tB_Core.IdUser);
            return View(tB_Core);
        }

        // POST: TB_Core/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCore,Name,Description,IdUser")] TB_Core tB_Core)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Core).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", tB_Core.IdUser);
            return View(tB_Core);
        }

        // GET: TB_Core/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Core tB_Core = db.TB_Core.Find(id);
            if (tB_Core == null)
            {
                return HttpNotFound();
            }
            return View(tB_Core);
        }

        // POST: TB_Core/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Core tB_Core = db.TB_Core.Find(id);
            db.TB_Core.Remove(tB_Core);
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
