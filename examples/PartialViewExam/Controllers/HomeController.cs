using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewExam.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Partial View => Kısmi görünümler isteğimiz bir view dosyasını istediğimiz alanda component mantığında kullanmak için oluşturulur.
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}