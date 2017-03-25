using SporMagazasi.WebUI.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace SporMagazasi.WebUI.HtmlHelpers
{
    public static class SayfalamaHelpers
    {
        public static System.Web.Mvc.MvcHtmlString SayfaLinkleri(
            this System.Web.Mvc.HtmlHelper html,
            SayfalamaBilgisi sayfalandirmaBilgisi,
            Func<int, string> sayfaURL)
        {

            StringBuilder sonuc = new StringBuilder();
            int toplamSayfa = sayfalandirmaBilgisi.ToplamSayfa;
            int simdikiSayfa = sayfalandirmaBilgisi.SimdikiSayfa;
            for (int i = 1; i <= toplamSayfa; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", sayfaURL(i));
                tag.InnerHtml = i.ToString();
                if (i == simdikiSayfa)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                sonuc.Append(tag.ToString());
            }
            return System.Web.Mvc.MvcHtmlString.Create(sonuc.ToString());

        }
    }
}