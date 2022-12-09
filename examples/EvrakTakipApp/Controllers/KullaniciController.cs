using EvrakTakipApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvrakTakipApp.Controllers
{
    public class KullaniciController : Controller
    {
        EvrakTakipDBEntity entity = new EvrakTakipDBEntity();
        // GET: Kullanici
        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 1)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");       

        }

        public ActionResult Olustur()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            
            if (yetkiId == 1)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");

        }

        [HttpPost]
        public ActionResult Olustur(string evrakAd,System.Web.HttpPostedFileBase yuklenecekDosya)
        {

            if (yuklenecekDosya != null)
            {
                try
                {
                    string dosyaAd = Path.GetFileName(yuklenecekDosya.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Evraklar"), dosyaAd);
                    string evrakYol = "/Evraklar/" + dosyaAd;

                    yuklenecekDosya.SaveAs(yuklemeYeri);

                    int personelID = Convert.ToInt32(Session["personelId"]);

                    Evraklar evrak = new Evraklar()
                    {
                        evrakAd = evrakAd,
                        perId = personelID,
                        evrakYol=evrakYol,
                        evrakTarih=DateTime.Now,
                        evrakDurumId=1,
                        evrakYerId=1
                    };

                    entity.Evraklar.Add(evrak);
                    entity.SaveChanges();

                    Raporlar rapor = new Raporlar()
                    {
                        evrakId = evrak.evrakId,
                        personelId = personelID,
                        tarih = DateTime.Now,
                        durumId = 1,
                        yerId = 1
                    };

                    entity.Raporlar.Add(rapor); 
                    entity.SaveChanges();

                    return RedirectToAction("Index", "Kullanici");


                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Kullanici");
                }
            }
            else
            {
                return View();

            }

        }

        public ActionResult Takip()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            int personelId = Convert.ToInt32(Session["personelId"]);

            if (yetkiId==1)
            {
                var evraklar = (from e in entity.Evraklar where e.perId == personelId select e).ToList();
                ViewBag.evraklar = evraklar;
                return View();
            }

            return RedirectToAction("Index","Login");

        }

        [HttpPost]
        public ActionResult Takip(int selectEvrak)
        {
            var rapor = (from r in entity.Raporlar where r.evrakId == selectEvrak select r).ToList();

            TempData["rapor"] = rapor;

            return RedirectToAction("Liste","Kullanici");

        }

        public ActionResult Liste()
        {
            List<Raporlar> raporlar = (List<Raporlar>)TempData["rapor"];

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

        public ActionResult Hata()
        {

            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            int personelId = Convert.ToInt32(Session["personelId"]);

            if(yetkiId == 1)
            {

                var evraklar = (from e in entity.Evraklar where e.evrakDurumId == 3 && e.perId == personelId select e).ToList();

                ViewBag.evraklar = evraklar;

                return View();

            }

            return RedirectToAction("Index","Login");
        }

        [HttpPost]

        public ActionResult Hata(int evrakId)
        {
            var evrak = (from e in entity.Evraklar where e.evrakId == evrakId select e).FirstOrDefault();
            
            TempData["evrak"] = evrak;

            return RedirectToAction("HataGonder","Kullanici");
        }

        public ActionResult HataGonder()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 1)
            {
                Evraklar evrak = (Evraklar)TempData["evrak"];

                ViewBag.evrak = evrak;

                return View();

            }

            return RedirectToAction("Index","Login");
        }

        [HttpPost]

        public ActionResult HataGonder(int evrakId,string evrakAd,HttpPostedFileBase yuklenecekDosya)
        {
            if(yuklenecekDosya != null) { 
                try
                {
                    string dosyaAd = Path.GetFileName(yuklenecekDosya.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Evraklar"), dosyaAd);
                    string evrakYol = "/Evraklar/" + dosyaAd;

                    yuklenecekDosya.SaveAs(yuklemeYeri);

                    int personelID = Convert.ToInt32(Session["personelId"]);

                    var evrak = (from e in entity.Evraklar where e.evrakId == evrakId select e).FirstOrDefault();

                    evrak.evrakAd = evrakAd;
                    evrak.evrakYol = evrakYol;
                    evrak.evrakDurumId = 2;
                    evrak.evrakYerId = 1;

                    entity.SaveChanges();

                    Raporlar rapor = new Raporlar()
                    {
                        evrakId = evrak.evrakId,
                        personelId = personelID,
                        tarih = DateTime.Now,
                        durumId = 2,
                        yerId = 1
                    };

                    entity.Raporlar.Add(rapor);
                    entity.SaveChanges();

                    return RedirectToAction("Takip", "Kullanici");


                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Kullanici");
                }
            }
            else
            {
                int personelID = Convert.ToInt32(Session["personelId"]);

                var evrak = (from e in entity.Evraklar where e.evrakId == evrakId select e).FirstOrDefault();
                evrak.evrakAd = evrakAd;
                evrak.evrakDurumId = 2;
                evrak.evrakYerId = 1;

                entity.SaveChanges();

                Raporlar rapor = new Raporlar()
                {
                    evrakId = evrak.evrakId,
                    personelId = personelID,
                    tarih = DateTime.Now,
                    durumId = 2,
                    yerId = 1
                };

                entity.Raporlar.Add(rapor);
                entity.SaveChanges();

                return RedirectToAction("Takip", "Kullanici");
            }
        }
    }
}