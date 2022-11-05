using ModelsModelBinding.Models;
using ModelsModelBinding.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelsModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            // instance (örneklem)  ORM (Object Relational Mapping)
            //Kisi kisi = new Kisi();
            //kisi.Ad = "Tahsin";
            //kisi.Soyad = "Canpolat";
            //kisi.Yas = 30;

            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 30
            };

            return View();
        }

        [HttpPost]
        public ActionResult HomePage(Kisi kisi)
        {
            // Formdan gelen nesneyi alır ve tekrardan view e yollar.
            return View(kisi);
        }


        public ActionResult HomePage2()
        {
            Kisi kisi = new Kisi()
            {
                Ad = "Tahsin",
                Soyad = "Canpolat",
                Yas = 30
              
            };

            Adres adres = new Adres()
            {
                AdresTanim = "Samandıra",
                Sehir = "İstanbul"
            };

            homepageViewModel model = new homepageViewModel();
            model.KisiNesnesi = kisi;
            model.AdresNesnesi = adres;
            return View(model);
        }
    }
}