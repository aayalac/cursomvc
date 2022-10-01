using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursomvc.Controllers;
using cursomvc.Models;

namespace cursomvc.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var oUser = (user)HttpContext.Current.Session["User"];
            if (oUser != null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}