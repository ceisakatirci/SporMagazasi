using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SporMagazasi.Domain.Entities
{
    public class Urun
    {
        [HiddenInput(DisplayValue = false)]
        public int UrunId { get; set; }
        [Required(ErrorMessage = "Ad giriniz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Açıklama giriniz")]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Geçerli bir fiyat giriniz")]
        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Kategori giriniz")]
        public string Kategori { get; set; }
        public byte[] GoruntuData { get; set; }
        public string GoruntuMimeType { get; set; }
    }
}
