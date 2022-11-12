using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string KategoriAd { get; set; }
        public double Fiyat { get; set; }
        public int StokMiktari { get; set; }
    }
}