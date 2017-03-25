using SporMagazasi.Domain.Abstract;
using SporMagazasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporMagazasi.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IUrunRepository repository;
        public AdminController(IUrunRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Urunler);
        }
        public ViewResult Guncelle(int urunId)
        {
            var urun = repository.Urunler
                .FirstOrDefault(u => u.UrunId == urunId);
            //if (urun == null)
            //{
            //    urun = new Urun();
            //}
            return View(urun);
        }
        [HttpPost]
        public ActionResult Guncelle(Urun urun,HttpPostedFileBase goruntu=null)
        {
            if (ModelState.IsValid)
            {
                if (goruntu != null)
                {
                    urun.GoruntuMimeType = goruntu.ContentType;
                    urun.GoruntuData=new byte[goruntu.ContentLength];
                    goruntu.InputStream.Read(urun.GoruntuData,0,goruntu.ContentLength);
                }
                repository.Kaydet(urun);
                TempData["mesaj"] = string.Format("{0} kaydedildi", urun.Ad);
                return RedirectToAction("Index");
            }
            else
            {
                // veri değerlerinde hata var
                return View(urun);
            }
        }
        public ViewResult Ekle()
        {
            return View("Guncelle", new Urun());
        }

        public ActionResult Sil(int urunId = -1)
        {
            Urun silinenUrun = repository.Sil(urunId);
            if (silinenUrun != null)
            {
                TempData["mesaj"] = string.Format("{0} silindi", silinenUrun.Ad);
            }
            return RedirectToAction("Index");
        }

       
    }
}