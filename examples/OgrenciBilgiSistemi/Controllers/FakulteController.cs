using OgrenciBilgiSistemi.DAL;
using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OgrenciBilgiSistemi.Controllers
{
    public class FakulteController : Controller
    {

        OBSContext veritabani = new OBSContext();
        // GET: Fakulte
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        // RedirectToRouteResult - Farklı bir action resulta yönlendirme işlemi yapar.
        public RedirectToRouteResult Ekle(Fakulte kayit)
        {
            veritabani.Fakulteler.Add(kayit);
            veritabani.SaveChanges();
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                action = "Ekle",
                controller = "Fakulte"
            }));
        }
        //public ActionResult Ekle(Fakulte kayit)
        //{
        //    veritabani.Fakulteler.Add(kayit);
        //    veritabani.SaveChanges();
        //    return RedirectToAction("Index","Fakulte");
        //}

        [HttpPost]
        public JsonResult Listele()
        {
            var fakulteler = veritabani.Fakulteler.ToList();
            return Json(fakulteler);
        }

        public ActionResult FakultelerJson()
        {
            return View();
        }

        public ActionResult Fakulteler()
        {
            var fakulteler = veritabani.Fakulteler.ToList().Select(f => new SelectListItem
            {
                Selected=false,
                Text = f.FakulteAd,
                Value = f.Id.ToString()
            }).ToList();

            ViewBag.Fakulteler = fakulteler;
            return View();
        }
    }
}