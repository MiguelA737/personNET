using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;
using MyWebApp.Repositories.Authentication;

namespace MyWebApp.Controllers
{
    public class TB_TextController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Text
        public ActionResult Index()
        {
            var tB_Text = db.TB_Text.Include(t => t.TB_Content);
            return View(tB_Text.ToList());
        }

        // GET: TB_Text/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Text tB_Text = db.TB_Text.Find(id);
            if (tB_Text == null)
            {
                return HttpNotFound();
            }
            return View(tB_Text);
        }

        // GET: TB_Text/Create
        public ActionResult Create()
        {
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType");
            return View();
        }

        // POST: TB_Text/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContent,ContentText,Title")] TB_Text tB_Text)
        {
            TB_Content tB_Content = new TB_Content
            {
                IdContent = db.TB_Content.Count(),
                ContentType = "Text",
                UploadDate = DateTime.Now,
                ContentViews = 0,
                IdUser = UserControl.VerifyUserStatus().IdUser
            };

            if (ModelState.IsValid)
            {
                db.TB_Content.Add(tB_Content);
                
                tB_Text.IdContent = tB_Content.IdContent;
                
                db.TB_Text.Add(tB_Text);
                db.SaveChanges();
                return Redirect("../MainPage/Index");
            }

            return View(tB_Text);
        }

        // GET: TB_Text/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Text tB_Text = db.TB_Text.Find(id);
            if (tB_Text == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Text.IdContent);
            return View(tB_Text);
        }

        // POST: TB_Text/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContent,ContentText,Title")] TB_Text tB_Text)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Text).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Text.IdContent);
            return View(tB_Text);
        }

        // GET: TB_Text/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Text tB_Text = db.TB_Text.Find(id);
            if (tB_Text == null)
            {
                return HttpNotFound();
            }
            return View(tB_Text);
        }

        // POST: TB_Text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Text tB_Text = db.TB_Text.Find(id);
            db.TB_Text.Remove(tB_Text);
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
