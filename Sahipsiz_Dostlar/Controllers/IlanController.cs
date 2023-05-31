using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Models;
using Sahipsiz_Dostlar.Repository;
using Sahipsizler_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers
{
    public class IlanController : Controller
    {
        IlanRepository IR = new IlanRepository();
        KategoriRepository KR = new KategoriRepository();
        // GET: Ilan
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.Ilanlar = IR.GetAll();
            vm.Kategori = KR.GetAll();
            return View(vm);
        }


        // GET: Icerikler/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Icerikler/Create
        [HttpPost]
        public ActionResult Create(Ilanlar ilan, HttpPostedFileBase ImgURL)
        {
            Console.WriteLine(ilan);
            if (ModelState.IsValid)
            {
                IR.Add(ilan, ImgURL);
                return RedirectToAction("Index");

            }
            return View(ilan);
        }

        // GET: Icerikler/Edit/ID
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilanlar ilan = IR.GetById(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Icerikler/Edit/ID
        [HttpPost]
        public ActionResult Edit(Ilanlar ilan, HttpPostedFileBase ImgURL)
        {
            try
            {
                IR.Update(ilan,ImgURL);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ilan/Delete/ID
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilanlar ilan = IR.GetById(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Delete/ID
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Ilanlar ilan)
        {
            IR.Delete(ilan);
            return RedirectToAction("Index");
        }
    }
}