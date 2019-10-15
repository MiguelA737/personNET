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
    public class TB_AdditionalDataController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_AdditionalData
        public ActionResult Index()
        {
            return View(db.TB_AdditionalData.ToList());
        }

        // GET: TB_AdditionalData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AdditionalData tB_AdditionalData = db.TB_AdditionalData.Find(id);
            if (tB_AdditionalData == null)
            {
                return HttpNotFound();
            }
            return View(tB_AdditionalData);
        }

        // GET: TB_AdditionalData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_AdditionalData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdditionalData,DataType,DataContent")] TB_AdditionalData tB_AdditionalData)
        {
            if (ModelState.IsValid)
            {
                db.TB_AdditionalData.Add(tB_AdditionalData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_AdditionalData);
        }

        // GET: TB_AdditionalData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AdditionalData tB_AdditionalData = db.TB_AdditionalData.Find(id);
            if (tB_AdditionalData == null)
            {
                return HttpNotFound();
            }
            return View(tB_AdditionalData);
        }

        // POST: TB_AdditionalData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdditionalData,DataType,DataContent")] TB_AdditionalData tB_AdditionalData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_AdditionalData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_AdditionalData);
        }

        // GET: TB_AdditionalData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AdditionalData tB_AdditionalData = db.TB_AdditionalData.Find(id);
            if (tB_AdditionalData == null)
            {
                return HttpNotFound();
            }
            return View(tB_AdditionalData);
        }

        // POST: TB_AdditionalData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_AdditionalData tB_AdditionalData = db.TB_AdditionalData.Find(id);
            db.TB_AdditionalData.Remove(tB_AdditionalData);
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
