using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Routing
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); // axd uzantılı dosyaları engelle
            routes.MapMvcAttributeRoutes();


            routes.MapRoute( // izin verilen yollar
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Anasayfa", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Anasayfa",
               url: "anasayfa",  // Bu url e gidildiğinde SiteController daki Anasayfa Methodu çalışır.
               defaults: new { controller = "Site", action = "Anasayfa", id = UrlParameter.Optional }
           );
        }
    }
}
