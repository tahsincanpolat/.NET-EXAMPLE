using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // *** State Management ***
            // Session (Oturumlar)
            // Application
            // Cookie (Çerezler)


            // Sessionlar (Oturumlar) - Sunucu tarafında tutulur. Key-value ilişkisiyle tutulur.

            Session.Add("egitmen","tahsin canpolat"); // Session oluşturma (key-value)
            Session.Add("sayi",10);
            Session["egitmen2"] = "Tahsin";
            Session.Remove("egitmen"); // Sessionı keye göre kaldırma işlemi
            Session.Abandon(); // Tüm sessionları sonlandırır.
            ViewBag.message = Session["egitmen"]; // session çağırma

            // Sessionlar kullanıcıya özelken
            // Applicationlar tüm kullanıcılara açık
            // Application State
            ViewBag.Online = HttpContext.Application["OnlineUyeSayisi"];

            return View();
        }

        public ActionResult About()
        {
            ViewBag.AboutMessage = Session["egitmen"]; // session çağırma
            return View();
        }

        public ActionResult Cookie()
        {
            // Sessionlar gibi kullanıcıya özeldir. Farkı kullanıcı tarafında tutulur. (Client) Kullanıcı istediği zaman silebilir.
            // Yaşam süresi (Expire Date) defaul olarak 30 dk. Kod ile 1 güne çıkaralım
            HttpCookie cookie = new HttpCookie("kullanici","Tahsin Canpolat");
            HttpCookie cookie2 = new HttpCookie("login", "true");
            HttpContext.Response.Cookies.Add(cookie);
            HttpContext.Response.Cookies.Add(cookie2);
            cookie.Expires = DateTime.Now.AddDays(1); // Cookie süresini 1 güne çıkarıyorum
            HttpContext.Response.Cookies.Remove("kullanici"); // Cookie silme işlemi

            ViewBag.Message = HttpContext.Response.Cookies["kullanici"].Value; // cookie çağırma

            return View();
        }
    }
}