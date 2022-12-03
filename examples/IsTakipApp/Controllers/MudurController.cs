using IsTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakipApp.Controllers
{
    public class MudurController : Controller
    {
        IsTakipDBEntities entity = new IsTakipDBEntities();

        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            if (yetkiId == 2)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Ilet()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 2)
            {
                int personelId = Convert.ToInt32(Session["personelId"]);

                var personel = (from p in entity.Personeller where p.personelId == personelId select p).FirstOrDefault();

                var personeller = (from per in entity.Personeller where per.personelBirimId == personel.personelBirimId select per).ToList();

                ViewBag.personeller = personeller;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public ActionResult Ilet(int selectPer)
        {
            var secilen = (from p in entity.Personeller where p.personelId == selectPer select p).FirstOrDefault();

            TempData["secilen"] = secilen;

            return RedirectToAction("Ata","Mudur");

        }

        public ActionResult Ata()
        {
            Personeller personel = (Personeller)TempData["secilen"];

            var isler = (from i in entity.Isler where i.isPersonelId == personel.personelId && i.isDurum == "iletiliyor" select i).ToList();

            ViewBag.isler = isler;
            ViewBag.personel = personel;

            return View();
        }

        [HttpPost]
        public ActionResult Ata(int isId)
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 2)
            { 
                var tekIs = (from i in entity.Isler where i.isId == isId select i).FirstOrDefault();
                tekIs.isDurum = "yapılıyor";
                tekIs.iletilenTarih = DateTime.Now;
                entity.SaveChanges();

                return RedirectToAction("Index", "Mudur");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        public ActionResult TakipIlet()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 2)
            {
                int personelId = Convert.ToInt32(Session["personelId"]);

                var personel = (from p in entity.Personeller where p.personelId == personelId select p).FirstOrDefault();

                var personeller = (from per in entity.Personeller where per.personelBirimId == personel.personelBirimId select per).ToList();

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

            return RedirectToAction("Takip", "Mudur");
        }

        public ActionResult Takip()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 2)
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

        public ActionResult Yap()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 2)
            {
                int personelId = Convert.ToInt32(TempData["secilen"]);

                var isler = (from i in entity.Isler where i.isPersonelId == personelId && i.isDurum=="yapılıyor" select i).ToList();

                ViewBag.isler = isler;

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]

        public ActionResult Yap(int isId)
        {
            var tekIs = (from i in entity.Isler where i.isId == isId select i).FirstOrDefault();

            tekIs.isDurum = "yapıldı";
            tekIs.yapilanTarih = DateTime.Now;

            entity.SaveChanges();

            return RedirectToAction("Index","Mudur");
        }
    }


}