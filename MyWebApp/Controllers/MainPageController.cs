﻿using MyWebApp.Models;
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