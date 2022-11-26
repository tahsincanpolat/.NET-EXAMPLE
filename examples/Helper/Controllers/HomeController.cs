using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Kisi kisi = new Kisi();
            kisi.Ad = "Tahsin";
            return View(kisi);
        }
    }
}