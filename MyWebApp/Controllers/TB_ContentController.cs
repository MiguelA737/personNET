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
    public class TB_ContentController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Content
        public ActionResult Index()
        {
            var tB_Content = db.TB_Content.Include(t => t.TB_User).Include(t => t.TB_Photo).Include(t => t.TB_Text).Include(t => t.TB_Video);
            return View(tB_Content.ToList());
        }

        // GET: TB_Content/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Content tB_Content = db.TB_Content.Find(id);
            if (tB_Content == null)
            {
                return HttpNotFound();
            }
            return View(tB_Content);
        }

        // GET: TB_Content/Create
        public ActionResult Create()
        {
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name");
            ViewBag.IdContent = new SelectList(db.TB_Photo, "IdContent", "DirPhoto");
            ViewBag.IdContent = new SelectList(db.TB_Text, "IdContent", "ContentText");
            ViewBag.IdContent = new SelectList(db.TB_Video, "IdContent", "DirVideo");
            return View();
        }

        // POST: TB_Content/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContent,ContentType,UploadDate,ContentViews,IdUser")] TB_Content tB_Content)
        {
            if (ModelState.IsValid)
            {
                db.TB_Content.Add(tB_Content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", tB_Content.IdUser);
            ViewBag.IdContent = new SelectList(db.TB_Photo, "IdContent", "DirPhoto", tB_Content.IdContent);
            ViewBag.IdContent = new SelectList(db.TB_Text, "IdContent", "ContentText", tB_Content.IdContent);
            ViewBag.IdContent = new SelectList(db.TB_Video, "IdContent", "DirVideo", tB_Content.IdContent);
            return View(tB_Content);
        }

        // GET: TB_Content/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Content tB_Content = db.TB_Content.Find(id);
            if (tB_Content == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", tB_Content.IdUser);
            ViewBag.IdContent = new SelectList(db.TB_Photo, "IdContent", "DirPhoto", tB_Content.IdContent);
            ViewBag.IdContent = new SelectList(db.TB_Text, "IdContent", "ContentText", tB_Content.IdContent);
            ViewBag.IdContent = new SelectList(db.TB_Video, "IdContent", "DirVideo", tB_Content.IdContent);
            return View(tB_Content);
        }

        // POST: TB_Content/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContent,ContentType,UploadDate,ContentViews,IdUser")] TB_Content tB_Content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", tB_Content.IdUser);
            ViewBag.IdContent = new SelectList(db.TB_Photo, "IdContent", "DirPhoto", tB_Content.IdContent);
            ViewBag.IdContent = new SelectList(db.TB_Text, "IdContent", "ContentText", tB_Content.IdContent);
            ViewBag.IdContent = new SelectList(db.TB_Video, "IdContent", "DirVideo", tB_Content.IdContent);
            return View(tB_Content);
        }

        // GET: TB_Content/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Content tB_Content = db.TB_Content.Find(id);
            if (tB_Content == null)
            {
                return HttpNotFound();
            }
            return View(tB_Content);
        }

        // POST: TB_Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Content tB_Content = db.TB_Content.Find(id);
            db.TB_Content.Remove(tB_Content);
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
