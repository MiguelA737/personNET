using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp.Repositories.Authentication
{
    public class UserControl
    {

        public static bool VerifyUserInDB(string email, string pass, bool persist)
        {
            try
            {
                personNETEntities db = new personNETEntities();
                var user = db.TB_User.Where(x => x.E_mail.Equals(email) && x.Pass.Equals(pass)).SingleOrDefault();
                if(user == null)
                {
                    return false;
                }
                else
                {
                    CookieControl.CreateCookie(user, persist);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static TB_User RecoverUser(int id)
        {
            try
            {
                personNETEntities db = new personNETEntities();
                var user = db.TB_User.Where(x => x.IdUser == id).SingleOrDefault();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static TB_User VerifyUserStatus()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UC"];

            if (cookie == null) return null;
            else
            {
                int idUser = Convert.ToInt32(cookie.Values["ID"]);
                var user = RecoverUser(idUser);
                return user;
            }

        }

    }
}