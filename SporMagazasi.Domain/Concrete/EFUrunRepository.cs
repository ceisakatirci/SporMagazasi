using SporMagazasi.Domain.Abstract;
using SporMagazasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporMagazasi.Domain.Concrete
{
    //referring to a particular; specific, not general or abstract - collinsdictionary
    public class EFUrunRepository : IUrunRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Urun> Urunler
        {
            get { return context.Urunler; }
        }


        public void Kaydet(Urun urun)
        {
            if (urun.UrunId == 0)
            {
                context.Urunler.Add(urun);
            }
            else
            {
                var dbEntry = context.Urunler.Find(urun.UrunId);
                if (dbEntry != null)
                {
                    dbEntry.Ad = urun.Ad;
                    dbEntry.Aciklama = urun.Aciklama;
                    dbEntry.Fiyat = urun.Fiyat;
                    dbEntry.Kategori = urun.Kategori;
                    dbEntry.GoruntuData = urun.GoruntuData;
                    dbEntry.GoruntuMimeType = urun.GoruntuMimeType;
                }
            }
            context.SaveChanges();
        }


        public Urun Sil(int urunId)
        {
            Urun dbEntry = context.Urunler.Find(urunId);
            if (dbEntry != null)
            {
                context.Urunler.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;

        }
    }
}
