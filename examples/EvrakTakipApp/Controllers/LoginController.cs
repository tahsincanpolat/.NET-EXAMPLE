using EvrakTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvrakTakipApp.Controllers
{
    public class LoginController : Controller
    {
        EvrakTakipDBEntity entity = new EvrakTakipDBEntity();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kullaniciAd,string parola)
        {
            var personel = (from p in entity.Personeller where p.perKullanici == kullaniciAd && p.perParola == parola select p).FirstOrDefault();

            if(personel != null)
            {
                Session["personelId"] = personel.perId;
                Session["yetkiId"] = personel.perYetkiId;

                if (personel.perYetkiId == 1)
                {
                    return RedirectToAction("Index","Kullanici");
                }
                if (personel.perYetkiId == 2)
                {
                    return RedirectToAction("Index", "OnMali");
                }
                if (personel.perYetkiId == 3)
                {
                    return RedirectToAction("Index", "Muhasebe");
                }
            }
            return View();
        }
    }
}