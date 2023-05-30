using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Entity.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required, StringLength(100, ErrorMessage = "100 karakter olmalıdır")]
        public string Eposta { get; set; }
        [Required, StringLength(100, ErrorMessage = "100 karakter olmalıdır")]
        public string Sifre { get; set; }
    }
}