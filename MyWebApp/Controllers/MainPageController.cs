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
        private personNETEntities db = new personNETEntities(); //substituir pelo nome da classe com as entidades --me passar para revisão depois de comentar o resto do programa(vinicius)

        public ActionResult Index()
        {

            ViewBag.Name = new SelectList(db.TB_User, "Name", "nome"); //parametro de pesquisa para retornar baseado no nome do usuario --me passar para revisão depois de comentar o resto do programa(vinicius)

            return View();
        }

        public ActionResult Search(Search pesquisa) //metodo de pesquisa W.I.P.--me passar para revisão depois de comentar o resto do programa(vinicius)
        {
            var post = from p in db.TB_User
                       where p.Name.Contains(pesquisa.Name)
                       select new SearchResult_User
                       {
                           Name = p.Name,
                           DirProfilePhoto = p.DirProfilePhoto
                       };

            return Json(post, JsonRequestBehavior.AllowGet);
        }
    }
}