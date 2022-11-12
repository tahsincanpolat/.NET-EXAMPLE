using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UrunController : ApiController
    {
        private List<Urun> urunlerListesi = new List<Urun>
        {
            new Urun{ Id=1,Ad="Masaüstü Bilgisayar",Fiyat=15000,StokMiktari=100 },
            new Urun{ Id=2,Ad="Dizüstü Bilgisayar",Fiyat=18000,StokMiktari=200 },
            new Urun{ Id=3,Ad="Cep Telefonu",Fiyat=25000,StokMiktari=1000 },
            new Urun{ Id=4,Ad="Ev Telefonu",Fiyat=1500,StokMiktari=300 },

        };

        public IEnumerable<Urun> GetAllUrun()
        {
            return urunlerListesi;
        }

        public IHttpActionResult GetUrun(int id)
        {
            var arananUrun = (from u in urunlerListesi where u.Id == id select u);
            if(arananUrun.Count() == 0)
            {
                return NotFound();
            }

            return Ok(arananUrun.FirstOrDefault());
        }
    }
}
