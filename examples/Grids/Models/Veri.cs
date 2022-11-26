using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grids.Models
{
    public class Veri
    {
        private static List<Urun> _urunler = new List<Urun>
        {
            new Urun{Id=1,Ad="Bilgisayar",Fiyat=20000,Adet=20 },
            new Urun{Id=2,Ad="Masa",Fiyat=500,Adet=200 },
            new Urun{Id=3,Ad="TV",Fiyat=15000,Adet=250 },
            new Urun{Id=4,Ad="Telefon",Fiyat=26000,Adet=300 },
            new Urun{Id=5,Ad="Kitap",Fiyat=100,Adet=1000 },
            new Urun{Id=1,Ad="Bilgisayar",Fiyat=20000,Adet=20 },
            new Urun{Id=2,Ad="Masa",Fiyat=500,Adet=200 },
            new Urun{Id=3,Ad="TV",Fiyat=15000,Adet=250 },
            new Urun{Id=4,Ad="Telefon",Fiyat=26000,Adet=300 },
            new Urun{Id=5,Ad="Kitap",Fiyat=100,Adet=1000 },
            new Urun{Id=1,Ad="Bilgisayar",Fiyat=20000,Adet=20 },
            new Urun{Id=2,Ad="Masa",Fiyat=500,Adet=200 },
            new Urun{Id=3,Ad="TV",Fiyat=15000,Adet=250 },
            new Urun{Id=4,Ad="Telefon",Fiyat=26000,Adet=300 },
            new Urun{Id=5,Ad="Kitap",Fiyat=100,Adet=1000 },
            new Urun{Id=1,Ad="Bilgisayar",Fiyat=20000,Adet=20 },
            new Urun{Id=2,Ad="Masa",Fiyat=500,Adet=200 },
            new Urun{Id=3,Ad="TV",Fiyat=15000,Adet=250 },
            new Urun{Id=4,Ad="Telefon",Fiyat=26000,Adet=300 },
            new Urun{Id=5,Ad="Kitap",Fiyat=100,Adet=1000 },

        };

        public List<Urun> urunler
        {
            get
            {
                return _urunler;
            }
        }

        public static List<Urun> UrunSorgula(string urunAd)
        {
            if (string.IsNullOrEmpty(urunAd))
            {
                return _urunler;
            }

            var urunler = (from u in _urunler where u.Ad.Contains(urunAd) select u).ToList();


            return urunler;

        }
    }
}