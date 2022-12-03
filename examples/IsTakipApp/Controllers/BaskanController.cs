using IsTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakipApp.Controllers
{
    public class BaskanController : Controller
    {
        IsTakipDBEntities entity = new IsTakipDBEntities();
        // GET: Baskan
        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            if (yetkiId == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        public ActionResult Ata()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if(yetkiId == 1) 
            {
                var yetkiPersonel = (from y in entity.Yetkiler where y.yetkiId == 1 select y).ToList();
                int personelId = Convert.ToInt32(yetkiPersonel[0].personelId);

                var personeller = (from p in entity.Personeller where p.personelId != personelId select p).ToList();

                ViewBag.personeller = personeller;

                return View();      
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Ata(string txtIs,string txtAciklama,string selectPer)
        {
            Isler isler = new Isler
            {
                isAd = txtIs,
                isAciklama = txtAciklama,
                isTarih = DateTime.Now,
                isPersonelId = Convert.ToInt32(selectPer),
                isDurum = "iletiliyor"
            };

            entity.Isler.Add(isler);
            entity.SaveChanges();
            return RedirectToAction("Index","Baskan");
        }

        public ActionResult TakipIlet()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 1)
            {
                int personelId = Convert.ToInt32(Session["personelId"]);

                var personeller = (from p in entity.Personeller where p.personelId != personelId select p).ToList();

                ViewBag.personeller = personeller;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]

        public ActionResult TakipIlet(int selectPer)
        {
            var secilen = (from p in entity.Personeller where p.personelId == selectPer select p).FirstOrDefault();

            TempData["secilen"] = secilen;

            return RedirectToAction("Takip","Baskan");
        }

        public ActionResult Takip()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 1)
            {
                Personeller personel = (Personeller)TempData["secilen"];

                var isler = (from i in entity.Isler where i.isPersonelId == personel.personelId select i).ToList();

                ViewBag.personel = personel;
                ViewBag.isler = isler;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}