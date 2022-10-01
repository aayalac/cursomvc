﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursomvc.Models;
using cursomvc.Models.TableViewModels;
using cursomvc.Models.ViewModels;

namespace cursomvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (cursomvcEntities db= new cursomvcEntities())
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
            using (var db= new cursomvcEntities())
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
    }
}