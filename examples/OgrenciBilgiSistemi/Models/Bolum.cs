using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OgrenciBilgiSistemi.Models
{
    public class Bolum
    {
        public int id { get; set; }
        [DisplayName("Bölüm Adı")]
        public string Ad { get; set; }
        [Required]
        public int FakulteId { get; set; }
        [DisplayName("Bölüm Adres")]
        public string Adres { get; set; }

        public Fakulte Fakulte;
    }
}