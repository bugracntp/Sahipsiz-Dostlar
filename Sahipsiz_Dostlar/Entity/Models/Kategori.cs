using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Entity.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        [DisplayName("Kategori Adı")]
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string KategoriAdi { get; set; }
        public ICollection<Ilanlar> Ilanlar { get; set; }
    }
}