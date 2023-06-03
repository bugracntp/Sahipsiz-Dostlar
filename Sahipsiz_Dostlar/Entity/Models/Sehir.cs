using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Entity.Models
{
    [Table("Sehirler")]
    public class Sehir
    {
        public int SehirID { get; set; }
        [Display(Name = "Şehir Adı")]
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string SehirAdi { get; set; }
    }
}