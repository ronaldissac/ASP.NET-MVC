using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerPortal.Models
{
    public class SessionValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["customerName"] == null ||
                string.IsNullOrWhiteSpace(filterContext.HttpContext.Session["customerName"].ToString()))
            {
                filterContext.Result = new RedirectResult("~/Login/LogOut");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}