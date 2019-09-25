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
    public class TB_GenreController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Genre
        public ActionResult Index()
        {
            var tB_Genre = db.TB_Genre.Include(t => t.TB_Core);
            return View(tB_Genre.ToList());
        }

        // GET: TB_Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Genre tB_Genre = db.TB_Genre.Find(id);
            if (tB_Genre == null)
            {
                return HttpNotFound();
            }
            return View(tB_Genre);
        }

        // GET: TB_Genre/Create
        public ActionResult Create()
        {
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name");
            return View();
        }

        // POST: TB_Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGenre,IdCore,GenreContent")] TB_Genre tB_Genre)
        {
            if (ModelState.IsValid)
            {
                db.TB_Genre.Add(tB_Genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", tB_Genre.IdCore);
            return View(tB_Genre);
        }

        // GET: TB_Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Genre tB_Genre = db.TB_Genre.Find(id);
            if (tB_Genre == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", tB_Genre.IdCore);
            return View(tB_Genre);
        }

        // POST: TB_Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGenre,IdCore,GenreContent")] TB_Genre tB_Genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", tB_Genre.IdCore);
            return View(tB_Genre);
        }

        // GET: TB_Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Genre tB_Genre = db.TB_Genre.Find(id);
            if (tB_Genre == null)
            {
                return HttpNotFound();
            }
            return View(tB_Genre);
        }

        // POST: TB_Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Genre tB_Genre = db.TB_Genre.Find(id);
            db.TB_Genre.Remove(tB_Genre);
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
