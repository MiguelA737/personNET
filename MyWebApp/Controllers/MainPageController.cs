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

        public ActionResult Search(Search pesquisa) //Verifica no DB se existem usuários cujos nomes contêm o termo pesquisado
        {
            //LINQ
            var users = from p in db.TB_User
                       where p.Name.Contains(pesquisa.Input)
                       select new SearchResult_User
                       {
                           User = p.Name,
                           Type = "User",
                           DirProfilePhoto = p.DirProfilePhoto
                       };

            var texts = from p in db.TB_Text
                        where p.ContentText.Contains(pesquisa.Input) || p.Title.Contains(pesquisa.Input)
                        select new SearchResult_Text
                        {
                            Title = p.Title,
                            ContentText = p.ContentText,
                            User = p.TB_Content.TB_User.Name,
                            UploadDate = p.TB_Content.UploadDate.ToString(),
                            Type = "Text"
                        };

            IEnumerable<SearchResult> post = users;
            post = post.Concat(texts);

            return Json(post, JsonRequestBehavior.AllowGet);
        }
    }
}