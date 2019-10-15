using MyWebApp.Repositories.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebApp.Filters
{
    public class AccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (controller != "Home")
            {
                if (UserControl.VerifyUserStatus() == null)
                {
                    filterContext.RequestContext.HttpContext.Response.Redirect("/Home/Login");
                }
            }
        }
    }
}