using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelsModelBinding.Models
{
    public class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public Adres Adres { get; set; }
    }
}