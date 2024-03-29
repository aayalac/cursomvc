﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Web.Mvc;
using cursomvc.Models.ViewModels;

namespace cursomvc.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            if (TempData["Message"] !=null)            
                ViewBag.Message = TempData["Message"].ToString();

                return View();                        
        }

        [HttpPost]
        public ActionResult Save(ArchivoViewModel model)
        {
            string RutaSitio = Server.MapPath("~/");
            string PathArchivo1 = Path.Combine(RutaSitio + "/Files/Archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Files/Archivo2.png");

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            model .Archivo1.SaveAs(PathArchivo1);
            model.Archivo2.SaveAs(PathArchivo2);

            @TempData["Message"] = "Se cargaron los archivos";
            return RedirectToAction("Index");
        }
    }
}