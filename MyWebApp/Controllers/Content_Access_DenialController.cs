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
    public class Content_Access_DenialController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: Content_Access_Denial
        public ActionResult Index()
        {
            var content_Access_Denial = db.Content_Access_Denial.Include(c => c.TB_Content).Include(c => c.TB_User);
            return View(content_Access_Denial.ToList());
        }

        // GET: Content_Access_Denial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content_Access_Denial content_Access_Denial = db.Content_Access_Denial.Find(id);
            if (content_Access_Denial == null)
            {
                return HttpNotFound();
            }
            return View(content_Access_Denial);
        }

        // GET: Content_Access_Denial/Create
        public ActionResult Create()
        {
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType");
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name");
            return View();
        }

        // POST: Content_Access_Denial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAccessDenial,IdUser,IdContent")] Content_Access_Denial content_Access_Denial)
        {
            if (ModelState.IsValid)
            {
                db.Content_Access_Denial.Add(content_Access_Denial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", content_Access_Denial.IdContent);
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", content_Access_Denial.IdUser);
            return View(content_Access_Denial);
        }

        // GET: Content_Access_Denial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content_Access_Denial content_Access_Denial = db.Content_Access_Denial.Find(id);
            if (content_Access_Denial == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", content_Access_Denial.IdContent);
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", content_Access_Denial.IdUser);
            return View(content_Access_Denial);
        }

        // POST: Content_Access_Denial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAccessDenial,IdUser,IdContent")] Content_Access_Denial content_Access_Denial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content_Access_Denial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", content_Access_Denial.IdContent);
            ViewBag.IdUser = new SelectList(db.TB_User, "IdUser", "Name", content_Access_Denial.IdUser);
            return View(content_Access_Denial);
        }

        // GET: Content_Access_Denial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content_Access_Denial content_Access_Denial = db.Content_Access_Denial.Find(id);
            if (content_Access_Denial == null)
            {
                return HttpNotFound();
            }
            return View(content_Access_Denial);
        }

        // POST: Content_Access_Denial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content_Access_Denial content_Access_Denial = db.Content_Access_Denial.Find(id);
            db.Content_Access_Denial.Remove(content_Access_Denial);
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
