using EntityLayer.Concrete;
using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class Stok : BaseEntity
    {

        public string StokKod { get; set; }
        public string StokAdi { get; set; }
        public string Aciklama1 { get; set; }
        public string Aciklama2 { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public string Birim { get; set; }
        public List<Kategori> Kategoriler { get; set; }
        public List<Fotograf> Fotograflar { get; set; }
    }
}
