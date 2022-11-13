using RssFeeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace RssFeeder.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            WebClient webclient = new WebClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            webclient.Encoding = Encoding.UTF8; // Türkçe karakter desteği

            string cekilenVeriler = webclient.DownloadString("https://www.hurriyet.com.tr/rss/spor");

            XDocument xmlHali = XDocument.Parse(cekilenVeriler);

            XNamespace media = XNamespace.Get("http://search.yahoo.com/mrss/"); // Resimleri almak için

            var cekilenRSSFeed = (from x in xmlHali.Descendants("item")
                                  select new Haberler
                                  {
                                      HaberBaslik =((string) x.Element("title")),
                                      HaberAciklama = ((string)x.Element("description")),
                                      HaberLink = ((string)x.Element("link")),
                                      HaberKategori = ((string)x.Element("category")),
                                      HaberResim = x.Element(media + "thumbnail") != null ? x.Element(media + "thumbnail").Attribute("url").Value : "img/news-placeholder.jpg"
                                  });
            // Ödev: Gündem,Spor,Ekonomi menüleri olacak ve menülere tıklandıkça haberler dinamik olarak değişecek
            return View(cekilenRSSFeed);
        }
    }
}