using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cursomvc.Content
{
    public class AcsessController : Controller
    {
        // GET: Acsess
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try 
            {
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :("+ex.Message);
            }
        }
    }
}