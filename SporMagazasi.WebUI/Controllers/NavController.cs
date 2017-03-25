using SporMagazasi.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SporMagazasi.WebUI.Controllers
{
    public class NavController : Controller
    {
        public IUrunRepository repository;
        public NavController(IUrunRepository repository)
        {
            this.repository = repository;
        }
        public PartialViewResult Menu(string kategori = null        )
        {
            ViewBag.SecilenKategori = kategori;
            var kategoriler = repository.Urunler
                .Select(x => x.Kategori)
                .Distinct()
                .OrderBy(x => x);

            //string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView("EsnekMenu", kategoriler);
        }
    }
}