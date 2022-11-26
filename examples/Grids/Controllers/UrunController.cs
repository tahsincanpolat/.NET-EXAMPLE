using Grids.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grids.Controllers
{
    public class UrunController : Controller
    {
        Veri veri = new Veri();
        // GET: Urun
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrunListesi()
        {
            
            return View(veri.urunler);
        }

        public ActionResult UrunAra()
        {
            return View();
        }


    }
}