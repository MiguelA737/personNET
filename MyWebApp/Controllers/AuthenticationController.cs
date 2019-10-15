using MyWebApp.Repositories.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        public JsonResult AuthenticateUser(string email, string pass, bool persist)
        {
            if (UserControl.VerifyUserInDB("" + email.GetHashCode(), "" + pass.GetHashCode(), persist))
                return Json(new { OK = true, Mensagem = "Usuário encontrado. Redirecionando..." }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { OK = false, Mensagem = "Usuário não encontrado." }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeauthenticateUser()
        {
            if (CookieControl.DeleteCookie())
                return Json(new { OK = true }, JsonRequestBehavior.AllowGet);
            else return Json(new { OK = false }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult VerifyAuthentication()
        {
            if (UserControl.VerifyUserStatus() != null)
                return Json(new { OK = true }, JsonRequestBehavior.AllowGet);
            else return Json(new { OK = false }, JsonRequestBehavior.AllowGet);
        }
    }
}