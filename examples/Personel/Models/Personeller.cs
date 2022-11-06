using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Personel.Models
{
    public class Personeller
    {
        public int Id { get; set; }
        [DisplayName("Personel Ad")]
        public string Ad { get; set; }
        [DisplayName("Personel Soyad")]
        public string Soyad { get; set; }
        [DisplayName("Personel TC Kimlik No")]
        public string TCKimlikNO { get; set; }
    }
}