using SporMagazasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporMagazasi.Domain.Abstract
{
    public interface IUrunRepository
    {
        IEnumerable<Urun> Urunler { get; }
        void Kaydet(Urun urun);
        Urun Sil(int urunId);
    }
}
