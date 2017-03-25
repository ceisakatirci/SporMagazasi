using SporMagazasi.WebUI.Infrastructure.Abstract;
using SporMagazasi.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporMagazasi.WebUI.Controllers
{
    public class HesapController : Controller
    {
        IYetkiProvider yetkiProvider;
        public HesapController(IYetkiProvider yetkiProvider)
        {
            this.yetkiProvider = yetkiProvider;
        }
        public ViewResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(GirisViewModel model, string oncekiUrl)
        {
            if (ModelState.IsValid)
            {
                if (yetkiProvider.KimlikDogrula(model.KullaniciAdi, model.Sifre))
                {
                    return Redirect(oncekiUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı yada şife hatalı");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}