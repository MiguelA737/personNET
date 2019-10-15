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
    public class Assoc_Core_ContentController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: Assoc_Core_Content
        public ActionResult Index()
        {
            var assoc_Core_Content = db.Assoc_Core_Content.Include(a => a.TB_Content).Include(a => a.TB_Core);
            return View(assoc_Core_Content.ToList());
        }

        // GET: Assoc_Core_Content/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assoc_Core_Content assoc_Core_Content = db.Assoc_Core_Content.Find(id);
            if (assoc_Core_Content == null)
            {
                return HttpNotFound();
            }
            return View(assoc_Core_Content);
        }

        // GET: Assoc_Core_Content/Create
        public ActionResult Create()
        {
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType");
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name");
            return View();
        }

        // POST: Assoc_Core_Content/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAssoc,IdCore,IdContent")] Assoc_Core_Content assoc_Core_Content)
        {
            if (ModelState.IsValid)
            {
                db.Assoc_Core_Content.Add(assoc_Core_Content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", assoc_Core_Content.IdContent);
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", assoc_Core_Content.IdCore);
            return View(assoc_Core_Content);
        }

        // GET: Assoc_Core_Content/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assoc_Core_Content assoc_Core_Content = db.Assoc_Core_Content.Find(id);
            if (assoc_Core_Content == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", assoc_Core_Content.IdContent);
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", assoc_Core_Content.IdCore);
            return View(assoc_Core_Content);
        }

        // POST: Assoc_Core_Content/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAssoc,IdCore,IdContent")] Assoc_Core_Content assoc_Core_Content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assoc_Core_Content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", assoc_Core_Content.IdContent);
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", assoc_Core_Content.IdCore);
            return View(assoc_Core_Content);
        }

        // GET: Assoc_Core_Content/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assoc_Core_Content assoc_Core_Content = db.Assoc_Core_Content.Find(id);
            if (assoc_Core_Content == null)
            {
                return HttpNotFound();
            }
            return View(assoc_Core_Content);
        }

        // POST: Assoc_Core_Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assoc_Core_Content assoc_Core_Content = db.Assoc_Core_Content.Find(id);
            db.Assoc_Core_Content.Remove(assoc_Core_Content);
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
