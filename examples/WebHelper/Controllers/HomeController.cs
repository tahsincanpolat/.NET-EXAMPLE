using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebHelper.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult ChartTekVeri()
        {
            return View();
        }

        public ActionResult ChartType()
        {
            return View();
        }
    }
}