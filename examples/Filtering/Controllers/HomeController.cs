using Filtering.Filter;
using Filtering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filtering.Controllers
{
    //[Log] // Controllerın logunu tutmak için
    public class HomeController : Controller
    {
        // GET: Home
        [Log]
        public ActionResult Index()
        {
            return View();
        }
        [Log]
        [HandleError(ExceptionType = typeof(FormatException), View = "Hata")]
        public ActionResult About()
        {
            throw new FormatException();
        }
        [Log]
        public ActionResult Contact()
        {
            return View();
        }

        [HandleError(ExceptionType = typeof(FormatException),View ="Hata")]
        public ActionResult Hata()
        {
            throw new FormatException();
        }

        public ActionResult Loglar()
        {
            return View(LogVeri.Loglar);
        }
    }
}