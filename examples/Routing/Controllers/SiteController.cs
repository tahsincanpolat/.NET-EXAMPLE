using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Routing.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        [Route("anasayfa")]  // RegisterRoutes taki MapRoute ın url i 
        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}