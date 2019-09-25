﻿using System;
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
    public class TB_PhotoController : Controller
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_Photo
        public ActionResult Index()
        {
            var tB_Photo = db.TB_Photo.Include(t => t.TB_Content);
            return View(tB_Photo.ToList());
        }

        // GET: TB_Photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Photo tB_Photo = db.TB_Photo.Find(id);
            if (tB_Photo == null)
            {
                return HttpNotFound();
            }
            return View(tB_Photo);
        }

        // GET: TB_Photo/Create
        public ActionResult Create()
        {
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType");
            return View();
        }

        // POST: TB_Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdContent,DirPhoto")] TB_Photo tB_Photo)
        {
            if (ModelState.IsValid)
            {
                db.TB_Photo.Add(tB_Photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Photo.IdContent);
            return View(tB_Photo);
        }

        // GET: TB_Photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Photo tB_Photo = db.TB_Photo.Find(id);
            if (tB_Photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Photo.IdContent);
            return View(tB_Photo);
        }

        // POST: TB_Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContent,DirPhoto")] TB_Photo tB_Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdContent = new SelectList(db.TB_Content, "IdContent", "ContentType", tB_Photo.IdContent);
            return View(tB_Photo);
        }

        // GET: TB_Photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Photo tB_Photo = db.TB_Photo.Find(id);
            if (tB_Photo == null)
            {
                return HttpNotFound();
            }
            return View(tB_Photo);
        }

        // POST: TB_Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Photo tB_Photo = db.TB_Photo.Find(id);
            db.TB_Photo.Remove(tB_Photo);
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
