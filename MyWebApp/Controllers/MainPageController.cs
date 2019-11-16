using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class MainPageController : RestrictedController
    {
        private personNETEntities db = new personNETEntities(); //Classe de entidades

        public ActionResult Index()
        {

            ViewBag.Name = new SelectList(db.TB_User, "Name", "nome"); //Lista de nomes existentes no banco (o search pesquisará nela)

            return View();
        }

        public ActionResult Search(Search search) //Verifica no DB se existem usuários cujos nomes contêm o termo pesquisado
        {
            //LINQ
            var users = from s in db.TB_User
                        where s.Name.Contains(search.Input)
                        select new SearchResult_User
                        {
                            User = s.Name,
                            DirProfilePhoto = s.DirProfilePhoto,
                            Type = "User"
                        };

            var texts = from s in db.TB_Text
                        where s.ContentText.Contains(search.Input) || s.Title.Contains(search.Input)
                        select new SearchResult_Text
                        {
                            Title = s.Title,
                            ContentText = s.ContentText,
                            User = s.TB_Content.TB_User.Name,
                            UploadDate = s.TB_Content.UploadDate.ToString(),
                            Type = "Text"
                        };

            var photos = from s in db.TB_Photo
                         where s.Title.Contains(search.Input)
                         select new SearchResult_Photo
                         {
                             Title = s.Title,
                             User = s.TB_Content.TB_User.Name,
                             DirPhoto = s.DirPhoto,
                             UploadDate = s.TB_Content.UploadDate.ToString(),
                             Type = "Photo"
                         };

            var videos = from s in db.TB_Video
                         where s.Title.Contains(search.Input)
                         select new SearchResult_Video
                         {
                             Title = s.Title,
                             User = s.TB_Content.TB_User.Name,
                             DirVideo = s.DirVideo,
                             UploadDate = s.TB_Content.UploadDate.ToString(),
                             Type = "Video"
                         };

            IEnumerable <SearchResult> post = users;
            post = post.Concat(texts);
            post = post.Concat(photos);
            post = post.Concat(videos);

            return Json(post, JsonRequestBehavior.AllowGet);
        }
    }
}