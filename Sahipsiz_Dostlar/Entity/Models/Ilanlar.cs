using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Entity.Models
{
    [Table("Ilanlar")]
    public class Ilanlar
    {
        [Key]
        public int HayvanId { get; set; }
        [DisplayName("İsim")]
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string Isim { get; set; }
        [DisplayName("Kategori")]
        public int? KategoriID { get; set; }
        public Kategori Kategori { get; set; }
        [DisplayName("Tür")]
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string Tur { get; set; }
        [DisplayName("Yaş")]
        [Required]
        public int Yas { get; set; }
        [DisplayName("Cinsiyet")]
        [Required, StringLength(5, ErrorMessage = "5 karakter olmalıdır")]
        public string Cinsiyet { get; set; }
        [DisplayName("Renk")]
        [Required, StringLength(20, ErrorMessage = "20 karakter olmalıdır")]
        public string Renk { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(250, ErrorMessage = "250 karakter olmalıdır")]
        public string Açıklama { get; set; }
        [DisplayName("Fotoğraf")]
        public string ImgURL { get; set; }
        [DisplayName("Durumu")]
        public bool SahiplendirmeDurumu { get; set; }
        public Kullanici SahipId { get; set; }
        public int? KullaniciId { get; set; }

    }
}