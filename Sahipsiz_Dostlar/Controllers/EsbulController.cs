using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Models;
using Sahipsiz_Dostlar.Repository;
using Sahipsizler_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers
{
    public class EsbulController : Controller
    {
        private readonly EsbulRepository ER = new EsbulRepository();
        private readonly KategoriRepository KR = new KategoriRepository();
        // GET: Esbul
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.Kategori = KR.GetAll();
            vm.Esbul = ER.GetAll();
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
        public ActionResult Create(Esbul ilan, HttpPostedFileBase ImgURL)
        {
            Console.WriteLine(ilan);
            if (ModelState.IsValid)
            {
                ER.Add(ilan, ImgURL);
                return RedirectToAction("Index");

            }
            return View(ilan);
        }
    }
}