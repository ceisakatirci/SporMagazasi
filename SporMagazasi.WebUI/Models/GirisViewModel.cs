using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SporMagazasi.WebUI.Models
{
    public class GirisViewModel
    {
        
        [Required]
        [Display(Name="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [Display(Name="Şifre")]
        public string Sifre { get; set; }
    }
}