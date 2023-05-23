using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cursomvc.Controllers
{
    public class CerrarController : Controller
    {
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Access");
        }
    }
}