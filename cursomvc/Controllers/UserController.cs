using cursomvc.Models;
using cursomvc.Models.TableViewModels;
using cursomvc.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Mvc;

namespace cursomvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (cursomvcEntities1 db = new cursomvcEntities1())
            {
                lst = (from d in db.user
                       where d.idState == 1
                       orderby d.email
                       select new UserTableViewModel
                       {
                           Email = d.email,
                           Id = d.id,
                           Edad = d.edad
                       }).ToList();
            }
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new cursomvcEntities1())
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);

                db.SaveChanges();
            }
            return Redirect(Url.Content("~/User/"));
        }

        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new cursomvcEntities1())
            {
                var oUser = db.user.Find(Id);
                model.Edad=(int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.id;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new cursomvcEntities1())
            {
                var oUser = db.user.Find(model.Id);
                oUser.email= model.Email;
                oUser.edad = model.Edad;

                if(model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new cursomvcEntities1())
            {
                var oUser = db.user.Find(Id);

                oUser.idState = 3; // Elimina

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Content("1");

        }

    }  

}
