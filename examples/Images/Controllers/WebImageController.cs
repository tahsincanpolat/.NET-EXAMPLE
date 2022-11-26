using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Images.Controllers
{
    public class WebImageController : Controller
    {

        private string ResimYolu
        {
            get
            {
                return Server.MapPath("~/Content/image.png");
            }
        }

        public void ResimGoruntule()
        {
            WebImage resim = new WebImage(ResimYolu);
            resim.Write();
        }

        public void ResimDondur()
        {
            WebImage resim = new WebImage(ResimYolu);
            resim.RotateRight();
            resim.FlipHorizontal();
            resim.FlipVertical();
            resim.Write();
        }
        public void ResimBoyutlandir()
        {
            WebImage resim = new WebImage(ResimYolu);
            resim.Resize(100, 100);
            resim.Write();
        }

        public void ResimKes()
        {
            WebImage resim = new WebImage(ResimYolu);
            resim.Crop(top:100,left:10,bottom:60,right:10);
            resim.Write();
        }

        public void ResimYaziEkleme()
        {
            WebImage resim = new WebImage(ResimYolu);
            resim.AddTextWatermark("Üçüncü bin yıl akademi",fontColor:"white",fontSize:20,opacity:20);
            resim.Write();
        }

        // GET: WebImage
        public ActionResult Index()
        {
            return View();
        }
    }
}