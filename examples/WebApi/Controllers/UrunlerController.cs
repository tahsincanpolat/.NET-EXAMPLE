using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        public ActionResult TumUrunler()
        {
            return View();
        }

        public ActionResult UrunGetir()
        {
            return View();
        }
    }
}