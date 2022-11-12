using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Routing.Controllers
{
    public class HaberKategoriController : Controller
    {
        // GET: HaberKategori
        [Route("Kategori/{kategori}")]
        public ActionResult Anasayfa(string kategori)
        {
            ViewBag.KategoriAd = kategori;
            return View();
        }

        [Route("Kategori/{kategori}/{altKategori}")]
        public ActionResult AltKategori(string altKategori)
        {
            ViewBag.KategoriAd = altKategori;
            return View();
        }

        [Route("Kategori/{kategori}/{altKategori}/{altAltKategori}")]
        public ActionResult AltAltKategori(string altAltKategori)
        {
            ViewBag.KategoriAd = altAltKategori;
            return View();
        }
    }
}