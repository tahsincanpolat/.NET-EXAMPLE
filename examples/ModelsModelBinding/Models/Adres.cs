using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelsModelBinding.Models
{
    public class Adres
    {
        public string AdresTanim { get; set; }
        public string Sehir { get; set; }

        // Eğer view e iki adet model yollamak istersek bunun için yeni bir klasör oluşturacağız bu klasör ViewModel
    }
}