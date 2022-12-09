using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvrakTakipApp.Models
{
    public class AyrintiliRapor
    {
        // Rapolar tablosunda sadece idler tutuluyor bize ayrıntılı propertyler lazım.
        public int evrakId { get; set; }
        public string evrakAd { get; set; }   
        public string personelAd { get; set; }  
        public DateTime tarih { get; set; }
        public string yerAd { get; set; }
        public string durumAd { get; set; }

    }
}
