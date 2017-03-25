using Ninject;
using SporMagazasi.Domain.Abstract;
using SporMagazasi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporMagazasi.WebUI.Controllers
{
    public class UrunController : Controller
    {
        private IUrunRepository repository;
        public int SayfaBoyutu = 4;
        [Inject]

        public UrunController(IUrunRepository urunRepository)
        {
            this.repository = urunRepository;
        }

        public ViewResult Listele(string kategori, int sayfa = 1)
        {

            UrunListesiViewModel model = new UrunListesiViewModel
            {
                Urunler = repository.Urunler
                .Where(u => kategori == null || u.Kategori == kategori)
                .OrderBy(u => u.UrunId)
                .Skip((sayfa - 1) * SayfaBoyutu)
                .Take(SayfaBoyutu),
                SayfalamaBilgisi = new SayfalamaBilgisi
                {
                    SimdikiSayfa = sayfa,
                    HerSayfadakiKalem = SayfaBoyutu,
                    ToplamKalem = kategori == null ? 
                    repository.Urunler.Count() :
                    repository.Urunler.Where(e=>e.Kategori == kategori).Count()
                },
                SimdikiKategori = kategori
            };

            return View(model);
        }

        public FileContentResult GoruntuGetir(int urunId)
        {
            var urun = repository.Urunler
            .FirstOrDefault(u => u.UrunId == urunId);
            if (urun != null)
            {
                return File(urun.GoruntuData, urun.GoruntuMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}