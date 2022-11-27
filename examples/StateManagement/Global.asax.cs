using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StateManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender,EventArgs e)
        {
            int onlineUyeSayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            onlineUyeSayisi = onlineUyeSayisi + 1;
            Application["OnlineUyeSayisi"] = onlineUyeSayisi;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            int onlineUyeSayisi = Convert.ToInt32(Application["OnlineUyeSayisi"]);
            onlineUyeSayisi = onlineUyeSayisi - 1;
            Application["OnlineUyeSayisi"] = onlineUyeSayisi;
        }


    }
}
