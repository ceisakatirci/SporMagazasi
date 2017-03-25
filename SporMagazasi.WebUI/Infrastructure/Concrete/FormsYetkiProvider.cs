using SporMagazasi.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SporMagazasi.WebUI.Infrastructure.Concrete
{
    public class FormsYetkiProvider : IYetkiProvider
    {
        public bool KimlikDogrula(string kullaniciAdi, string sifre)
        {
            bool result = FormsAuthentication.Authenticate(kullaniciAdi, sifre);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(kullaniciAdi, false);
            }
            return result;
        }
    }
}