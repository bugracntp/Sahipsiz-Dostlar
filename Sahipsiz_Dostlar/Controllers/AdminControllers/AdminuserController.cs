using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers
{
    public class AdminuserController : Controller
    {
        private readonly KullaniciRepository KR = new KullaniciRepository();

        // GET: Adminuser
        public ActionResult Index()
        {
            return View(KR.GetAll());
        }

        // GET: Adminuser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = KR.GetById(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // GET: Adminuser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adminuser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KullaniciID,Ad,Soyad,Email,Tel,Adress,DogumTarihi,Password,IsEmailVerified,ActivationCode")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                KR.Add(kullanici);
                return RedirectToAction("Index");
            }

            return View(kullanici);
        }

        // GET: Adminuser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanici kullanici = KR.GetById(id);
            if (kullanici == null)
            {
                return HttpNotFound();
            }
            return View(kullanici);
        }

        // POST: Adminuser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KullaniciID,Eposta,Sifre,Ad,Soyad,Telefon,Adres")] Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                KR.Update(kullanici);
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        // GET: Adminuser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using(var db = new Sahipsiz_DostlarDB())
            {
                Kullanici kullanici = db.Kullanici.Find(id);
                if (kullanici == null)
                {
                    return HttpNotFound();
                }
                return View(kullanici);
            }

        }

        // POST: Adminuser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new Sahipsiz_DostlarDB())
            {
                Kullanici kisi = db.Kullanici.Find(id);
                db.Kullanici.Remove(kisi);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using(var db = new Sahipsiz_DostlarDB())
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
