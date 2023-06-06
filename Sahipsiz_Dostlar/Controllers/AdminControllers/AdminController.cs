using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (Sahipsiz_DostlarDB DB = new Sahipsiz_DostlarDB())
            {
                return View(DB.Admin.ToList()) ;
            }
        }

        public ActionResult Adminlogin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Adminlogin(Admin loginModel)
        {
            using (Sahipsiz_DostlarDB DB = new Sahipsiz_DostlarDB())
            {
                var login = DB.Admin.Where(x => x.Eposta == loginModel.Eposta).SingleOrDefault();
                if (login != null)
                {
                    if (login.Sifre == Crypto.Hash(loginModel.Sifre))
                    {
                        Session["AdminID"] = login.AdminID;
                        Session["Eposta"] = login.Eposta;
                        Session["Sifre"] = login.Sifre;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Hata = "Şifre Hatalı";
                        return View("Adminlogin");
                    }
                }
                else
                {
                    ViewBag.Hata = "Eposta Hatalı";
                    return View("Adminlogin");
                }
            }
        }

        public ActionResult AdminAdd()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            using (Sahipsiz_DostlarDB DB = new Sahipsiz_DostlarDB())
            {
                var login = DB.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
                if (login != null)
                {
                    ViewBag.Hata = "Bu Eposta Kullanılmaktadır";
                    return View("AdminAdd");
                }
                else
                {
                    admin.Sifre = Crypto.Hash(admin.Sifre);
                    DB.Admin.Add(admin);
                    DB.SaveChanges();
                    return RedirectToAction("Adminlogin");
                }
            }
            return View();
        }

        public ActionResult Adminlogout()
        {
            Session["AdminID"] = null;
            Session["Eposta"] = null;
            Session["Sifre"] = null;
            return RedirectToAction("Adminlogin");
        }
    }
}