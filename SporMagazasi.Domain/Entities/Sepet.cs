using SporMagazasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporMagazasi.Domain.Entities
{
    public class Sepet
    {
        private List<SepetUrun> sepetUrunler = new List<SepetUrun>();
        public void UrunEkle(Urun urun, int adet)
        {
            SepetUrun sepetUrun = sepetUrunler
                        .Where(u => u.Urun.UrunId == urun.UrunId)
                        .FirstOrDefault();
            if (sepetUrun == null)
            {
                sepetUrunler.Add(
                    new SepetUrun
                    {
                        Urun = urun,
                        Adet = adet
                    });
            }
            else
            {
                sepetUrun.Adet += adet;
            }
        }

        public void UrunCikar(Urun urun)
        {
            sepetUrunler.RemoveAll(u => u.Urun.UrunId == urun.UrunId);
        }
        public decimal ToplamTutariHesapla()
        {
            return sepetUrunler.Sum(u => u.Urun.Fiyat * u.Adet);
        }
        public void SepetiBosalt()
        {
            sepetUrunler.Clear();
        }

        public IEnumerable<SepetUrun> SepetUrunler
        {
            get { return sepetUrunler; }
        }

    }
    public class SepetUrun
    {
        public Urun Urun { get; set; }
        public int Adet { get; set; }

    }
}