using System.Net;
using System.Net.Mail;
using System.Text;
using SporMagazasi.Domain.Abstract;
using SporMagazasi.Domain.Entities;

namespace SporMagazasi.Domain.Concrete
{
    public class EpostaAyarlari
    {
        public string Alici = "siparisler@spormagazasi.com";
        public string Gonderen = "info@spormagazasi.com";
        public bool SslKullanilsinMi = true;
        public string KullaniciAdi = "SmtpKullaniciAdi";
        public string Sifre = "SmtpSifre";
        public string SunucuAdi = "smtp.spormagazasi.com";
        public int SunucuPortu = 587;
        public bool DosyaOlarakYaz = false;
        public string DosyaYeri = @"c:\spor_magazasi_eposta_adresleri";
    }
    public class EpostaSiparisIsleme : ISiparisIsleme
    {
        private EpostaAyarlari epostaAyarlari;
        public EpostaSiparisIsleme(EpostaAyarlari epostaAyarlari)
        {
            this.epostaAyarlari = epostaAyarlari;
        }
        public void SiparisiIslemeAl(Sepet sepet, TeslimatDetaylari teslimatDetaylari)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = epostaAyarlari.SslKullanilsinMi;
                smtpClient.Host = epostaAyarlari.SunucuAdi;
                smtpClient.Port = epostaAyarlari.SunucuPortu;
                //Kimlik bilgileri
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(
                            epostaAyarlari.KullaniciAdi,
                            epostaAyarlari.Sifre);
                if (epostaAyarlari.DosyaOlarakYaz)
                {
                    smtpClient.DeliveryMethod
                            = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = epostaAyarlari.DosyaYeri;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder govde = new StringBuilder()
                .AppendLine("Yeni bir sipariş verildi")
                .AppendLine("---")
                .AppendLine("Sipariş Kalemler:");

                foreach (var sepetUrun in sepet.SepetUrunler)
                {
                    var araToplam = sepetUrun.Urun.Fiyat * sepetUrun.Adet;
                    govde.AppendFormat("{0} x {1} (Ara Toplam:{2:c})",
                        sepetUrun.Adet,
                        sepetUrun.Urun.Ad,
                        araToplam);
                }

                govde.AppendFormat("Total order value: {0:c}", sepet.ToplamTutariHesapla())
                        .AppendLine("---")
                        .AppendLine("Ship to:")
                        .AppendLine(teslimatDetaylari.Ad)
                        .AppendLine(teslimatDetaylari.Soyad)
                        .AppendLine(teslimatDetaylari.Satir1 ?? "")
                        .AppendLine(teslimatDetaylari.Satir2 ?? "")
                        .AppendLine(teslimatDetaylari.Satir3 ?? "")
                        .AppendLine(teslimatDetaylari.Il)
                        .AppendLine(teslimatDetaylari.Ilce)
                        .AppendLine(teslimatDetaylari.PostaKodu)
                        .AppendLine("---")
                        .AppendFormat("Hediye Paketi: {0}",
                        teslimatDetaylari.HediyePaketiMi ? "Evet" : "Hayır");

                MailMessage mesaj = new MailMessage(
                        epostaAyarlari.Gonderen,
                        epostaAyarlari.Alici,
                        "Yeni sipariş verildi!",
                        govde.ToString());
                if (epostaAyarlari.DosyaOlarakYaz)
                {
                    mesaj.BodyEncoding = Encoding.UTF8;
                }
                smtpClient.Send(mesaj);
            }
        }
    }
}
