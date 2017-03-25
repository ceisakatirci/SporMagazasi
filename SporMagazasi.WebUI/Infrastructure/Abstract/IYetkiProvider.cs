using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SporMagazasi.WebUI.Infrastructure.Abstract
{
    public interface IYetkiProvider
    {
        bool KimlikDogrula(string kullaniciAdi, string sifre);
    }
}