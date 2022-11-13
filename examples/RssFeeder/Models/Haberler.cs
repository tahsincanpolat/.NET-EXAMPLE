using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RssFeeder.Models
{
    public class Haberler
    {
        public string HaberBaslik { get; set; }
        public string HaberAciklama { get; set; }
        public string HaberLink { get; set; }
        public string HaberResim { get; set; }
        public string HaberKategori { get; set; }
    }
}