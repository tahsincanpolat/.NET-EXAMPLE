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
    
    public partial class Yetkiler
    {
        public Yetkiler()
        {
            this.Personeller = new HashSet<Personeller>();
        }
    
        public int yetkiId { get; set; }
        public string yetkiAd { get; set; }
    
        public virtual ICollection<Personeller> Personeller { get; set; }
    }
}