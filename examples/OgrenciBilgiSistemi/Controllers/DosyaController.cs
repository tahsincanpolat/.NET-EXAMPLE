using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OgrenciBilgiSistemi.Controllers
{
    public class DosyaController : Controller
    {
        // GET: Dosya
        public ActionResult Index()
        {
            return View();
        }

        public FileResult UniversiteBilgi()
        {
            string dosyaYolu = Server.MapPath("~/Files/Universitemiz.txt");
            string dosyaIcerikTur = "text/plain";
            return new FilePathResult(dosyaYolu,dosyaIcerikTur);
        }

        public FileStreamResult UniversiteStreamBilgi()
        {
            string metin = "deneme yazisi";
            MemoryStream register = new MemoryStream();
            byte[] bytes = Encoding.UTF8.GetBytes(metin);
            register.Write(bytes,0,metin.Length);
            register.Position = 0;

            FileStreamResult fileStreamResult = new FileStreamResult(register,"text/plain");
            fileStreamResult.FileDownloadName = "Bilgi.txt";

            return fileStreamResult;
        }

    }
}