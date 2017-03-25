using System.Web.Mvc;
using SporMagazasi.Domain.Entities;

namespace SporMagazasi.WebUI.Infrastructure.Binders
{
    public class SepetModelBinder : IModelBinder
    {
        private const string sessionKey = "Sepet";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            //  session'dan sepeti al
            Sepet sepet = null;
            if (controllerContext.HttpContext.Session != null)
            {
                sepet = (Sepet)controllerContext.HttpContext.Session[sessionKey];
            }
            // session verisinde yoksa sepet oluştur  
            if (sepet == null)
            {
                sepet = new Sepet();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = sepet;
                }
            }
            // sepeti dönder
            return sepet;
        }
    }
}