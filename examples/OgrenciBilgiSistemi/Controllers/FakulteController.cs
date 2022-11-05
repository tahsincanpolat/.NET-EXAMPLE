using OgrenciBilgiSistemi.DAL;
using OgrenciBilgiSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Ekle(Fakulte kayit)
        {
            veritabani.Fakulteler.Add(kayit);
            veritabani.SaveChanges();
            return RedirectToAction("Index","Fakulte");
        }

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
    }
}