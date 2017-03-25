
using Ninject;
using SporMagazasi.Domain.Abstract;
using SporMagazasi.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using SporMagazasi.WebUI.Infrastructure.Concrete;
using SporMagazasi.WebUI.Infrastructure.Abstract;

namespace SporMagazasi.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //Mock<IUrunRepository> mock = new Mock<IUrunRepository>();
            //mock.Setup(m => m.Urunler).Returns(new List<Urun> {
            //    new Urun { Ad = "Futbol", Fiyat = 25 },
            //    new Urun { Ad = "Sörf Tahtası", Fiyat = 179 },
            //    new Urun { Ad = "Koşu Ayakkabısı", Fiyat = 95 }
            //});
            //kernel.Bind<IUrunRepository>().ToConstant(mock.Object);
            kernel.Bind<IUrunRepository>().To<EFUrunRepository>();
            EpostaAyarlari epostaAyarlari = new EpostaAyarlari
            {
                DosyaOlarakYaz = bool.Parse(ConfigurationManager
                .AppSettings["Eposta.DosyaOlarakYaz"] ?? "false")
            };
            kernel.Bind<ISiparisIsleme>().To<EpostaSiparisIsleme>()
                .WithConstructorArgument("epostaAyarlari", epostaAyarlari);
            kernel.Bind<IYetkiProvider>().To<FormsYetkiProvider>();
        }
    }
}