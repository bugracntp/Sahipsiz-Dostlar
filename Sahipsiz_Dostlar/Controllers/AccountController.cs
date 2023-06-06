using Sahipsiz_Dostlar.Entity.Context;
using Sahipsiz_Dostlar.Entity.Models;
using Sahipsiz_Dostlar.Models;
using Sahipsiz_Dostlar.Repository;
using Sahipsiz_Dostlar.Validators;
using Sahipsizler_Dostlar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sahipsiz_Dostlar.Controllers
{
    public class AccountController : Controller
    {
        private readonly EsbulRepository ER = new EsbulRepository();
        private readonly IlanRepository IR = new IlanRepository();
        private readonly KullaniciRepository KUR = new KullaniciRepository();
        // GET: Account
        public ActionResult login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Kullanici loginModel)
        {
            using (Sahipsiz_DostlarDB DB = new Sahipsiz_DostlarDB())
            {
                var login = DB.Kullanici.Where(x => x.Email == loginModel.Email).SingleOrDefault();
                if (login != null)
                {
                    if (login.Password == Crypto.Hash(loginModel.Password))
                    {
                        Session["KullaniciID"] = login.KullaniciID;
                        Session["Eposta"] = login.Email;
                        Session["Sifre"] = login.Password;
                        ViewBag.login = "Hoşgeldin" + login.Ad+" "+login.Soyad;
                        return RedirectToAction("Index", "Anasayfa");
                    }
                    else
                    {
                        ViewBag.Hata = "Şifre Hatalı";
                        return View("Login");
                    }
                }
                else
                {
                    ViewBag.Hata = "Eposta Hatalı";
                    return View("Login");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Exclude = "IsEmailVerified,ActivationCode")] Kullanici user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExist = KUR.IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                #endregion
                user.IsEmailVerified = false;

                #region Save to Database
                using (Sahipsiz_DostlarDB dc = new Sahipsiz_DostlarDB())
                {
                    dc.Kullanici.Add(user);
                    dc.SaveChanges();

                    var verifyUrl = "/Account/VerifyAccount/" + user.ActivationCode.ToString();
                    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                    //Send Email to User
                    EmailSender.SendVerificationLinkEmail(user.Email , link);
                    message = "Registration successfully done. Account activation link " +
                        " has been sent to your email id:" + user.Email;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return RedirectToAction("Index", "Anasayfa");
        }


        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (Sahipsiz_DostlarDB dc = new Sahipsiz_DostlarDB())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                                // Confirm password does not match issue on save changes
                var v = dc.Kullanici.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        public ActionResult Logout()
        {
            Session["KullaniciID"] = null;
            Session["Eposta"] = null;
            Session["Sifre"] = null;
            return RedirectToAction("Index", "Anasayfa");
        }

        public ActionResult Profil()
        {
            Session["KullaniciID"] = 1;
            if (Session["KullaniciID"] != null)
            {
                int id = Convert.ToInt32(Session["KullaniciID"]);
                var kullanici = KUR.GetById(id);
                using (var db = new Sahipsiz_DostlarDB())
                {
                    ViewModel vm = new ViewModel();
                    vm.Ilanlar = db.Ilanlar.Where(x => x.KullaniciId == id).ToList();
                    vm.Esbul = db.Esbul.Where(x => x.KullaniciId == id).ToList();

                    return View(vm);
                }
            }
            else
            {
                return RedirectToAction("Index", "Anasayfa");
            }
        }
    }
}