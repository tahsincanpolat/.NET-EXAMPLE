//------------------------------------------------------------------------------
// <auto-generated>
//    Bu kod bir şablondan oluşturuldu.
//
//    Bu dosyada el ile yapılan değişiklikler uygulamanızda beklenmedik davranışa neden olabilir.
//    Kod yeniden oluşturulursa, bu dosyada el ile yapılan değişikliklerin üzerine yazılacak.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvrakTakipApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evraklar
    {
        public Evraklar()
        {
            this.Raporlar = new HashSet<Raporlar>();
        }
    
        public int evrakId { get; set; }
        public string evrakAd { get; set; }
        public Nullable<int> perId { get; set; }
        public string evrakYol { get; set; }
        public Nullable<System.DateTime> evrakTarih { get; set; }
        public Nullable<int> evrakDurumId { get; set; }
        public Nullable<int> evrakYerId { get; set; }
    
        public virtual Durumlar Durumlar { get; set; }
        public virtual Yerler Yerler { get; set; }
        public virtual ICollection<Raporlar> Raporlar { get; set; }
    }
}