using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewExam.Controllers
{
    public class HomeController : Controller  // Inheritance
    {
        // GET: Home
        public ActionResult Index()  // Geri Action Result (View) döndüren method - Sağ tık görünüm ekle
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}