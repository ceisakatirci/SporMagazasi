using SporMagazasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporMagazasi.WebUI.Models
{
    public class UrunListesiViewModel
    {
        public IEnumerable<Urun> Urunler { get; set; }
        public SayfalamaBilgisi SayfalamaBilgisi { get; set; }
        public string SimdikiKategori { get; set; }
    }
}