using EvrakTakipApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvrakTakipApp.Controllers
{
    public class OnMaliController : Controller
    {
        EvrakTakipDBEntities entity = new EvrakTakipDBEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 2)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");       

        }

        public ActionResult Bekleyen()
        {

            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 2)
            {
                var evraklar = (from e in entity.Evraklar where e.evrakDurumId == 1 && e.evrakYerId==1 select e).ToList();
                ViewBag.evraklar = evraklar;
                return View();

            }
            return RedirectToAction("Index","Login");
        }

        [HttpPost]

        public ActionResult Bekleyen(int evrakId)
        {
            int personelId = Convert.ToInt32(Session["personelId"]);

            var evrak = (from e in entity.Evraklar where e.evrakId == evrakId select e).FirstOrDefault();

            evrak.evrakDurumId = 2;
            entity.SaveChanges();

            Raporlar rapor = new Raporlar()
            {
                personelId = personelId,
                durumId = 2,
                yerId = 1,
                tarih = DateTime.Now,
                evrakId = evrak.evrakId              
            };

            entity.Raporlar.Add(rapor);
            entity.SaveChanges();

            return RedirectToAction("Incelenen","OnMali");
        }


        public ActionResult Incelenen()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 2)
            {
                var evraklar = (from e in entity.Evraklar where e.evrakDurumId == 2 && e.evrakYerId == 1 select e).ToList();

                ViewBag.evraklar = evraklar;

                return View();
            }

            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public ActionResult Incelenen(string btnBasarili,string btnHatali, int evrakId)
        {
            int personelId = Convert.ToInt32(Session["personelId"]);
            if (btnBasarili != null)
            {
                var evrak = (from e in entity.Evraklar where e.evrakId == evrakId select e).FirstOrDefault();

                evrak.evrakDurumId = 2;
                evrak.evrakDurumId = 2;
                entity.SaveChanges();

                Raporlar rapor = new Raporlar()
                {
                    personelId = personelId,
                    durumId = 2,
                    yerId = 2,
                    tarih = DateTime.Now,
                    evrakId = evrak.evrakId
                };

                entity.Raporlar.Add(rapor);
                entity.SaveChanges();

                return RedirectToAction("Basarili", "OnMali");
            }
            if (btnHatali != null)
            {
                var evrak = (from e in entity.Evraklar where e.evrakId == evrakId select e).FirstOrDefault();

                evrak.evrakDurumId = 3;
                entity.SaveChanges();

                Raporlar rapor = new Raporlar()
                {
                    personelId = personelId,
                    durumId = 3,
                    yerId = 1,
                    tarih = DateTime.Now,
                    evrakId = evrak.evrakId
                };

                entity.Raporlar.Add(rapor);
                entity.SaveChanges();

                return RedirectToAction("Hata", "OnMali");
            }

            return View();
        }

        public ActionResult Hata()
        {
            var raporlar = (from r in entity.Raporlar where r.durumId == 3 && r.yerId == 1 select r).ToList();

            List<AyrintiliRapor> list = new List<AyrintiliRapor>();

            foreach (var item in raporlar)
            {
                AyrintiliRapor ar = new AyrintiliRapor()
                {
                    evrakId = item.Evraklar.evrakId,
                    evrakAd = item.Evraklar.evrakAd,
                    tarih = Convert.ToDateTime(item.tarih),
                    personelAd = item.Personeller.perAd,
                    yerAd = item.Yerler.yerAd,
                    durumAd = item.Durumlar.durumAd
                };

                list.Add(ar);
            }

            ViewBag.raporlar = list;

            return View();
        }
        public ActionResult Basarili()
        {
            var raporlar = (from r in entity.Raporlar where r.durumId == 2 && r.yerId == 2 select r).ToList();

            List<AyrintiliRapor> list = new List<AyrintiliRapor>();

            foreach (var item in raporlar)
            {
                AyrintiliRapor ar = new AyrintiliRapor()
                {
                    evrakId = item.Evraklar.evrakId,
                    evrakAd = item.Evraklar.evrakAd,
                    tarih = Convert.ToDateTime(item.tarih),
                    personelAd = item.Personeller.perAd,
                    yerAd = item.Yerler.yerAd,
                    durumAd = item.Durumlar.durumAd
                };

                list.Add(ar);
            }

            ViewBag.raporlar = list;

            return View();
        }



    }
}