using IsTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakipApp.Controllers
{
    public class MemurController : Controller
    {
        IsTakipDBEntities entity = new IsTakipDBEntities();

        // GET: Memur
        public ActionResult Index()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 3)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }

        public ActionResult Yap()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);

            if (yetkiId == 3)
            {
                int personelId = Convert.ToInt32(Session["personelId"]);

                var isler = (from i in entity.Isler where i.isPersonelId == personelId && i.isDurum == "yapılıyor" select i).ToList();

                ViewBag.isler = isler;

                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        [HttpPost]
        public ActionResult Yap(int isId)
        {
            var tekIs = (from i in entity.Isler where i.isId == isId select i).FirstOrDefault();

            tekIs.isDurum = "yapıldı";
            tekIs.yapilanTarih = DateTime.Now;
            entity.SaveChanges();
            return RedirectToAction("Index","Memur");
        }

        public ActionResult Takip()
        {
            int yetkiId = Convert.ToInt32(Session["yetkiId"]);
            if(yetkiId == 3)
            {
                int personelId = Convert.ToInt32(Session["personelId"]);

                var isler = (from i in entity.Isler where i.isPersonelId == personelId select i).ToList();

                ViewBag.isler = isler;
                return View();

            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}