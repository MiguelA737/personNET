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
    public class TB_UserController : RestrictedController
    {
        private personNETEntities db = new personNETEntities();

        // GET: TB_User
        public ActionResult Index()
        {
            return View(db.TB_User.ToList());
        }

        // GET: TB_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_User tB_User = db.TB_User.Find(id);
            if (tB_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUser = tB_User.IdUser;
            return View(tB_User);
        }

        // GET: TB_User/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,Name,E_mail,Pass,DirProfilePhoto,BirthDate,LastAccess,HasPremiumAccess")] TB_User tB_User)
        {
            if (db.TB_User.ToList().Find(x => x.E_mail.Equals("" + tB_User.E_mail.GetHashCode())) == null)
            {
                if (ModelState.IsValid)
                {
                    tB_User.Pass = "" + tB_User.Pass.GetHashCode();
                    tB_User.E_mail = "" + tB_User.E_mail.GetHashCode();
                    db.TB_User.Add(tB_User);
                    db.SaveChanges();
                    return Redirect("../MainPage/Index");
                }
            }
            return View(tB_User);
        }

        // GET: TB_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_User tB_User = db.TB_User.Find(id);
            if (tB_User == null)
            {
                return HttpNotFound();
            }
            return View(tB_User);
        }

        // POST: TB_User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,Name,E_mail,Pass,DirProfilePhoto,BirthDate,LastAccess,HasPremiumAccess")] TB_User tB_User)
        {
            if (ModelState.IsValid)
            {
                tB_User.Pass = "" + tB_User.Pass.GetHashCode();
                tB_User.E_mail = "" + tB_User.E_mail.GetHashCode();
                db.Entry(tB_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_User);

        }

        // GET: TB_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_User tB_User = db.TB_User.Find(id);
            if (tB_User == null)
            {
                return HttpNotFound();
            }
            return View(tB_User);
        }

        public ActionResult UserPosts(int id)
        {
            var texts = from s in db.TB_Text
                        where s.TB_Content.IdUser == id
                        select new SearchResult_Text
                        {
                            Title = s.Title,
                            ContentText = s.ContentText,
                            User = s.TB_Content.TB_User.Name,
                            UploadDate = s.TB_Content.UploadDate.ToString(),
                            Type = "Text",
                            IdUser = s.TB_Content.IdUser
                        };

            var photos = from s in db.TB_Photo
                         where s.TB_Content.IdUser == id
                         select new SearchResult_Photo
                         {
                             Title = s.Title,
                             User = s.TB_Content.TB_User.Name,
                             DirPhoto = s.DirPhoto,
                             UploadDate = s.TB_Content.UploadDate.ToString(),
                             Type = "Photo",
                             IdUser = s.TB_Content.IdUser
                         };

            var videos = from s in db.TB_Video
                         where s.TB_Content.IdUser == id
                         select new SearchResult_Video
                         {
                             Title = s.Title,
                             User = s.TB_Content.TB_User.Name,
                             DirVideo = s.DirVideo,
                             UploadDate = s.TB_Content.UploadDate.ToString(),
                             Type = "Video",
                             IdUser = s.TB_Content.IdUser
                         };

            IEnumerable<SearchResult> post = texts;
            post = post.Concat(photos);
            post = post.Concat(videos);

            return Json(post, JsonRequestBehavior.AllowGet);
        }

        // POST: TB_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_User tB_User = db.TB_User.Find(id);
            db.TB_User.Remove(tB_User);
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
