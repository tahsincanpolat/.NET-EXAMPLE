using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewData["text"] = "Tahsin Canpolat";  // key value
            //ViewData["dogru"] = true;

            //ViewBag.text = "Tahsin Canpolat";
            //ViewBag.dogru = true;

            TempData["text"] = "Tahsin Canpolat"; // key value
            TempData["dogru"] = true;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.text1 = "Uğur Çelik";
            ViewBag.check = false;
            ViewBag.liste = new SelectListItem[] {
                                new SelectListItem() { Text = "Ali" },
                                new SelectListItem() { Text = "Veli" },
                            };

            TempData["t1"] = ViewBag.text1;
            TempData["c1"] = ViewBag.check;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.text = TempData["t1"];  // Tempdata["t1"] index methodunda tanımlı olmadığı için indexten contacte gittiğimizde ViewBag e eşitleme yapmaz.
            return View();
        }

    }
}