using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grids.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }
        public int Adet { get; set; }
    }
}