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
    public class TB_NotificationController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Notification
        public ActionResult Index()
        {
            return View(db.TB_Notification.ToList());
        }

        // GET: TB_Notification/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Notification tB_Notification = db.TB_Notification.Find(id);
            if (tB_Notification == null)
            {
                return HttpNotFound();
            }
            return View(tB_Notification);
        }

        // GET: TB_Notification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_Notification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdNotification,Content")] TB_Notification tB_Notification)
        {
            if (ModelState.IsValid)
            {
                db.TB_Notification.Add(tB_Notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Notification);
        }

        // GET: TB_Notification/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Notification tB_Notification = db.TB_Notification.Find(id);
            if (tB_Notification == null)
            {
                return HttpNotFound();
            }
            return View(tB_Notification);
        }

        // POST: TB_Notification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdNotification,Content")] TB_Notification tB_Notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Notification);
        }

        // GET: TB_Notification/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Notification tB_Notification = db.TB_Notification.Find(id);
            if (tB_Notification == null)
            {
                return HttpNotFound();
            }
            return View(tB_Notification);
        }

        // POST: TB_Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Notification tB_Notification = db.TB_Notification.Find(id);
            db.TB_Notification.Remove(tB_Notification);
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
