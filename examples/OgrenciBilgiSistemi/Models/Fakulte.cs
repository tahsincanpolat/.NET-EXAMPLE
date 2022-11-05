using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OgrenciBilgiSistemi.Models
{
    public class Fakulte
    {
        public int Id { get; set; }
        [DisplayName("Fakülte Adı")]
        [Required]
        public string FakulteAd { get; set; }
        [DisplayName("Silindi")]
        [Required]
        public bool Sil { get; set; }
    }
}