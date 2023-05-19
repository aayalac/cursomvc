using System;
using System.Linq;
using System.Web.Mvc;
using cursomvc.Models;

namespace cursomvc.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (cursomvcEntities1 db = new cursomvcEntities1())
                {
                    var lst = from d in db.user
                              where d.email == user && d.password == password && d.idState == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: " + ex.Message);
            }
        }
    }
}