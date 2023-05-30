using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsizler_Dostlar.Repository;

namespace Sahipsiz_Dostlar.Controllers
{
    public class AdminilanController : Controller
    {
        private readonly Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();
        private readonly IlanRepository IR = new IlanRepository();


        // GET: Adminilan
        public ActionResult Index()
        {
            Session["KullaniciID"] = 1;
            return View(IR.GetAll());
        }

        // GET: Adminilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ilan = IR.GetById(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Adminilan/Create
        public ActionResult Create()
        {
            ViewBag.KategoriList = new SelectList(db.Kategori, "KategoriID", "KategoriAdi");
            return View();
        }

        // POST: Adminilan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HayvanId,Isim,Tur,Yas,Cinsiyet,Renk,Açıklama,ImgURL")] Ilanlar ilanlar)
        {
            if (ModelState.IsValid)
            {
                ilanlar.KullaniciId = Convert.ToInt32(Session["KullaniciID"]);
                IR.Add(ilanlar);
                return RedirectToAction("Index");
            }

            return View(ilanlar);
        }

        // GET: Adminilan/Edit/5
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

        // POST: Adminilan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HayvanId,Isim,Tur,Yas,Cinsiyet,Renk,Açıklama,SahiplendirmeDurumu,ImgURL")] Ilanlar ilanlar)
        {
            if (ModelState.IsValid)
            {
                IR.Update(ilanlar);   
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
            Ilanlar ilan = IR.GetById(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Adminilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Ilanlar ilan)
        {
            IR.Delete(ilan);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
