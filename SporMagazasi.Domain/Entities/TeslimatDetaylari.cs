using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SporMagazasi.Domain.Entities
{
    public class TeslimatDetaylari
    {
        [Required(ErrorMessage = "Ad giriniz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad giriniz")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "İlk gelen adres satırını doldurunuz")]
        [Display(Name = "Satır 1")]
        public string Satir1 { get; set; }
        [Display(Name = "Satır 2")]
        public string Satir2 { get; set; }
        [Display(Name = "Satır 3")]
        public string Satir3 { get; set; }
        [Required(ErrorMessage = "İl adı giriniz")]
        [Display(Name = "İl")]
        public string Il { get; set; }
        [Required(ErrorMessage = "İlçe adı giriniz")]
        [Display(Name = "İlçe")]
        public string Ilce { get; set; }
         [Display(Name = "PostaKodu")]
        public string PostaKodu { get; set; }
         [Display(Name = "Hediye Paketi Mi?")]
        public bool HediyePaketiMi { get; set; }
    }
}
