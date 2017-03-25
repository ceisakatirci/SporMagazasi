using SporMagazasi.Domain.Abstract;
using SporMagazasi.Domain.Entities;
using SporMagazasi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SporMagazasi.WebUI.Controllers
{
    public class SepetController : Controller
    {
        private IUrunRepository repository;
        private ISiparisIsleme siparisIsleme;
        public SepetController(IUrunRepository repository, ISiparisIsleme siparisIsleme)
        {
            this.repository = repository;
            this.siparisIsleme = siparisIsleme;
        }
        public ViewResult Index(Sepet sepet, string oncekiUrl)
        {
            return View(new SepetIndexViewModel
            {
                OncekiUrl = oncekiUrl,
                Sepet = sepet
            });
        }
        public RedirectToRouteResult SepeteEkle(Sepet sepet, int urunId, string oncekiUrl)
        {
            var urun = repository.Urunler
                        .FirstOrDefault(x => x.UrunId == urunId);
            if (urun != null)
            {
                sepet.UrunEkle(urun, 1);
            }
            return RedirectToAction("Index", new { oncekiUrl });
        }
        public RedirectToRouteResult SepetetenCikar(Sepet sepet, int urunId, string oncekiUrl)
        {
            var urun = repository.Urunler
                        .FirstOrDefault(x => x.UrunId == urunId);
            if (urun != null)
            {
                sepet.UrunCikar(urun);
            }
            return RedirectToAction("Index", new { oncekiUrl });
        }
        public PartialViewResult Ozet(Sepet sepet)
        {
            return PartialView(sepet);
        }
        //private Sepet SepetiGetir()
        //{
        //    Sepet sepet = (Sepet)Session["Sepet"];
        //    if (sepet == null)
        //    {
        //        sepet = new Sepet();
        //        Session["Sepet"] = sepet;
        //    }
        //    return sepet;
        //}

        public ViewResult AlisverisiTamamla()
        {
            return View(new TeslimatDetaylari());
        }
        [HttpPost]
        public ViewResult AlisverisiTamamla(Sepet sepet, TeslimatDetaylari teslimatDetaylari)
        {
            if (sepet.SepetUrunler.Count() == 0)
            {
                ModelState.AddModelError("","Maalesef, sepetiniz boş!");
            }
            if (ModelState.IsValid)
            {
                siparisIsleme.SiparisiIslemeAl(sepet,teslimatDetaylari);
                sepet.SepetiBosalt();
                return View("Tamamlandi");
            }
            else
            {
                return View(teslimatDetaylari);
            }
        }
    }
}