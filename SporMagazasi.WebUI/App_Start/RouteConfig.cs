using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SporMagazasi.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new
                {
                    controller = "Urun",
                    action = "Listele",
                    kategori = (string)null,
                    sayfa = 2
                });

            routes.MapRoute(
                name: null,
                url: "Sayfa{sayfa}",
                defaults: new
                {
                    controller = "Urun",
                    action = "Listele",
                    kategori = (string)null
                },
                constraints: new
                {
                    sayfa = @"\d+"
                });

            routes.MapRoute(
                name: null,
                url: "{kategori}",
                defaults: new
                {
                    controller = "Urun",
                    action = "Listele",
                    sayfa = 1
                });

            routes.MapRoute(
                name: null,
                 url: "{kategori}/Sayfa{sayfa}",
                defaults: new
                {
                    controller = "Urun",
                    action = "Listele"
                },
                   constraints: new
                {
                    sayfa = @"\d+"
                });

            routes.MapRoute(
                name: null,
                url: "{controller}/{action}");
        }
    }
}
