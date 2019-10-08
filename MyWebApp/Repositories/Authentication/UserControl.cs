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
                var usuario = db.TB_User.Where(x => x.E_mail.Equals(email) && x.Pass.Equals(pass)).SingleOrDefault();
                if(usuario == null)
                {
                    return false;
                }
                else
                {
                    CookieControl.CreateCookie(usuario, persist);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}