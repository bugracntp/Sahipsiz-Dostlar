using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Models;
using Sahipsiz_Dostlar.Repository;
using Sahipsizler_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers
{
    public class EsbulController : Controller
    {
        private readonly EsbulRepository ER = new EsbulRepository();
        private readonly KategoriRepository KR = new KategoriRepository();
        private readonly KullaniciRepository KUR = new KullaniciRepository();
        // GET: Esbul
        public ActionResult Index(int? id)
        {
            ViewModel vm = new ViewModel();
            vm.Esbul = id != null ? ER.GetAll().Where(x => x.KategoriID == id).ToList() : ER.GetAll();
            vm.Kategori = KR.GetAll();
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esbul esbul = ER.GetById(id);
            ViewBag.Kategori = KR.GetById(esbul.KategoriID).KategoriAdi;
            ViewBag.Kullanici = KUR.GetById(esbul.KullaniciId).Ad + " " + KUR.GetById(esbul.KullaniciId).Soyad;
            ViewBag.Iletisim = KUR.GetById(esbul.KullaniciId).Tel;
            using (var db = new Sahipsiz_DostlarDB())
            {
                ViewBag.Sehir = db.Sehirler.Where(x => x.SehirID == esbul.SehirID).FirstOrDefault().SehirAdi;
            }
            if (esbul == null)
            {
                return HttpNotFound();
            }
            return View(esbul);
        }
        // GET: Icerikler/Create
        [HttpGet]
        public ActionResult Create()
        {
            Session["KullaniciID"] = 1;
            Sahipsiz_DostlarDB db = new Sahipsiz_DostlarDB();
            ViewBag.KategoriList = new SelectList(db.Kategori, "KategoriID", "KategoriAdi");
            ViewBag.SehirlerList = new SelectList(db.Sehirler, "SehirID", "SehirAdi");
            return View();
        }


        // POST: Icerikler/Create
        [HttpPost]
        public ActionResult Create(Esbul ilan, HttpPostedFileBase ImgURL)
        {
            ilan.KullaniciId = Convert.ToInt32(Session["KullaniciID"]);
            if (ModelState.IsValid)
            {
                ER.Add(ilan, ImgURL);
                return RedirectToAction("Index");

            }
            return View(ilan);
        }
    }
}