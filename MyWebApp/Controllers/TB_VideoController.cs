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
    public class TB_VideoController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Video
        public ActionResult Index()
        {
            var tB_Video = db.TB_Video.Include(t => t.TB_Content);
            return View(tB_Video.ToList());
        }

        // GET: TB_Video/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Video tB_Video = db.TB_Video.Find(id);
            if (tB_Video == null)
            {
                return HttpNotFound();
            }
            return View(tB_Video);
        }

        // GET: TB_Video/Create
        public ActionResult Create()
        {
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType");
            return View();
        }

        // POST: TB_Video/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContent,DirVideo")] TB_Video tB_Video)
        {
            if (ModelState.IsValid)
            {
                db.TB_Video.Add(tB_Video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Video.IdContent);
            return View(tB_Video);
        }

        // GET: TB_Video/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Video tB_Video = db.TB_Video.Find(id);
            if (tB_Video == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Video.IdContent);
            return View(tB_Video);
        }

        // POST: TB_Video/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContent,DirVideo")] TB_Video tB_Video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Video.IdContent);
            return View(tB_Video);
        }

        // GET: TB_Video/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Video tB_Video = db.TB_Video.Find(id);
            if (tB_Video == null)
            {
                return HttpNotFound();
            }
            return View(tB_Video);
        }

        // POST: TB_Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Video tB_Video = db.TB_Video.Find(id);
            db.TB_Video.Remove(tB_Video);
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
