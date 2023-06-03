using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers.AdminControllers
{
    public class AdminesbulController : Controller
    {
        private readonly EsbulRepository ER = new EsbulRepository();
        // GET: Adminesbul
        public ActionResult Index()
        {
            Session["KullaniciID"] = 1;
            return View(ER.GetAll());
        }


        // GET: Adminilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ilan = ER.GetById(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Adminilan/Create
        public ActionResult Create()
        {
            Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();
                ViewBag.KategoriList = new SelectList(db.Kategori, "KategoriID", "KategoriAdi");
                ViewBag.SehirlerList = new SelectList(db.Sehirler, "SehirID", "SehirAdi");

            return View();
        }

        // POST: Adminilan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HayvanId,Isim,KategoriID,Tur,Yas,Cinsiyet,Renk,Açıklama,SehirID,ImgURL,SahiplendirmeDurumu,KullaniciId")] Esbul ilanlar, HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                ilanlar.KullaniciId = Convert.ToInt32(Session["KullaniciID"]);
                ER.Add(ilanlar, ImgURL);
                return RedirectToAction("Index");
            }

            return View(ilanlar);
        }

        // GET: Adminilan/Edit/5
        public ActionResult Edit(int? id)
        {

            Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esbul ilan = ER.GetById(id);
                ViewBag.KategoriList = new SelectList(db.Kategori, "KategoriID", "KategoriAdi");
                ViewBag.SehirlerList = new SelectList(db.Sehirler, "SehirID", "SehirAdi");
 
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Adminilan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HayvanId,Isim,KategoriID,Tur,Yas,Cinsiyet,Renk,Açıklama,SehirID,ImgURL,SahiplendirmeDurumu,KullaniciId")] Esbul ilanlar, HttpPostedFileBase ImgURL)
        {
            if (ModelState.IsValid)
            {
                ER.Update(ilanlar, ImgURL);
                return RedirectToAction("Index");
            }
            return View(ilanlar);
        }

        // GET: Adminilan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esbul ilan = ER.GetById(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Adminilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            using (var db = new Sahipsiz_DostlarDB())
            {
                var silinecekIlan = db.Esbul.Find(id);
                db.Esbul.Remove(silinecekIlan);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using (var db = new Sahipsiz_DostlarDB())
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}