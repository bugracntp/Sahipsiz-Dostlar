﻿using Sahipsiz_Dostlar.Entity.Context;
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
    public class AdminkategoriController : Controller
    {
        private readonly Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();
        private readonly KategoriRepository KR = new KategoriRepository();

        // GET: AdminCins
        public ActionResult Index()
        {
            return View(KR.GetAll());
        }

        // GET: AdminCins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = KR.GetById(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // GET: AdminCins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriID,KategoriAdi")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                KR.Add(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: AdminCins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = KR.GetById(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: AdminCins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriID,KategoriAdi")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                KR.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        // GET: AdminCins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = db.Kategori.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }

        // POST: AdminCins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Kategori kategori)
        {
            KR.Delete(kategori);
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
