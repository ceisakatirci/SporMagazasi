using SporMagazasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporMagazasi.Domain.Abstract
{
    public interface ISiparisIsleme
    {
        void SiparisiIslemeAl(Sepet sepet, TeslimatDetaylari teslimatDetaylari);
    }
}
