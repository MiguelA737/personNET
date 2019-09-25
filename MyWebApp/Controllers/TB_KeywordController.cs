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
    public class TB_KeywordController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Keyword
        public ActionResult Index()
        {
            var tB_Keyword = db.TB_Keyword.Include(t => t.TB_Core);
            return View(tB_Keyword.ToList());
        }

        // GET: TB_Keyword/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Keyword tB_Keyword = db.TB_Keyword.Find(id);
            if (tB_Keyword == null)
            {
                return HttpNotFound();
            }
            return View(tB_Keyword);
        }

        // GET: TB_Keyword/Create
        public ActionResult Create()
        {
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name");
            return View();
        }

        // POST: TB_Keyword/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdKeyword,IdCore,KeywordContent")] TB_Keyword tB_Keyword)
        {
            if (ModelState.IsValid)
            {
                db.TB_Keyword.Add(tB_Keyword);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", tB_Keyword.IdCore);
            return View(tB_Keyword);
        }

        // GET: TB_Keyword/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Keyword tB_Keyword = db.TB_Keyword.Find(id);
            if (tB_Keyword == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", tB_Keyword.IdCore);
            return View(tB_Keyword);
        }

        // POST: TB_Keyword/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdKeyword,IdCore,KeywordContent")] TB_Keyword tB_Keyword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Keyword).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCore = new SelectList(db.TB_Core, "IdCore", "Name", tB_Keyword.IdCore);
            return View(tB_Keyword);
        }

        // GET: TB_Keyword/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Keyword tB_Keyword = db.TB_Keyword.Find(id);
            if (tB_Keyword == null)
            {
                return HttpNotFound();
            }
            return View(tB_Keyword);
        }

        // POST: TB_Keyword/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Keyword tB_Keyword = db.TB_Keyword.Find(id);
            db.TB_Keyword.Remove(tB_Keyword);
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
