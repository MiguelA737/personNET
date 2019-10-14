using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Repositories.Authentication
{
    public class CookieControl
    {

        public static void CreateCookie(TB_User tB_User, bool persist)
        {

            HttpCookie userCookie = new HttpCookie("UC");
            userCookie.Values["ID"] = "" + tB_User.IdUser;
            userCookie.Values["E-mail"] = "" + tB_User.E_mail;
            userCookie.Values["Pass"] = tB_User.Pass;

            if (persist) userCookie.Expires = DateTime.Now.AddDays(365);

            HttpContext.Current.Response.Cookies.Add(userCookie);

        }

    }
}