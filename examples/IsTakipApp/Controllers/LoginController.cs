using IsTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsTakipApp.Controllers
{
    public class LoginController : Controller
    {
        IsTakipDBEntities entity = new IsTakipDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kullaniciAd,string parola)
        {
            var personel = (from p in entity.Personeller where p.personelKullaniciAd == kullaniciAd && p.personelParola == parola select p).FirstOrDefault();
           
            if(personel != null)
            {
                Session["personelAd"] = personel.personelAd;
                Session["personelId"] = personel.personelId;

                var yetki = (from y in entity.Yetkiler where y.personelId == personel.personelId select y).FirstOrDefault();

                Session["yetkiId"] = yetki.yetkiTurId;

                if(yetki.yetkiTurId == 1)
                {
                    return RedirectToAction("Index","Baskan");
                }
                if (yetki.yetkiTurId == 2)
                {
                    return RedirectToAction("Index", "Mudur");
                }
                if (yetki.yetkiTurId == 3)
                {
                    return RedirectToAction("Index", "Memur");
                }
            }
            else
            {
                return View();
            }
            
            
            return View();
        }
    }
}