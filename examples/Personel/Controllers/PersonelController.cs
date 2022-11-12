using Personel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personel.Controllers
{
    public class PersonelController : Controller
    {
        private static List<Personeller> PersonellerListesi = new List<Personeller>
        {
            new Personeller{ Id=1,Ad="Ali",Soyad="Güçlü",TCKimlikNO="111"},
            new Personeller{ Id=2,Ad="Ahmet",Soyad="Güçlü",TCKimlikNO="222"},
            new Personeller{ Id=3,Ad="Veli",Soyad="Güçlü",TCKimlikNO="333"},
            new Personeller{ Id=4,Ad="Ayşe",Soyad="Güçlü",TCKimlikNO="555"},

        };
        // GET: Personel
        
        public ActionResult Personel()
        {
            return View(PersonellerListesi);
        }

        public ActionResult Sil(int id)
        {
            var silinecek = PersonellerListesi.Where(p => p.Id == id).FirstOrDefault();
            PersonellerListesi.Remove(silinecek);

            return RedirectToAction("Personel", "Personel");
        }

        public ActionResult PersonelAra()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PersonelAramaSonucu(string personelAra)
        {
            ViewBag.ArananKelime = personelAra;
            var sonuc = PersonellerListesi.Where(p => p.Ad.Contains(personelAra)).ToList();
            return View(sonuc);
        }

        public ActionResult YeniPersonel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(Personeller per)
        {
            Random rnd = new Random();

            Personeller personel = new Personeller
            {
                Id = rnd.Next(),
                Ad = per.Ad,
                Soyad = per.Soyad,
                TCKimlikNO = per.TCKimlikNO
            };
            PersonellerListesi.Add(personel);
            return RedirectToAction("Personel","Personel");
        }


    }
}