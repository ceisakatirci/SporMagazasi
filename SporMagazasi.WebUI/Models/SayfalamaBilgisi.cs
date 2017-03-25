using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporMagazasi.WebUI.Models
{
    public class SayfalamaBilgisi
    {
        public int ToplamKalem { get; set; }
        public int HerSayfadakiKalem { get; set; }
        public int SimdikiSayfa { get; set; }


        public int ToplamSayfa
        {
            get
            {
                return (int)Math.Ceiling(
                    (decimal)ToplamKalem / HerSayfadakiKalem);
            }

        }

    }
}