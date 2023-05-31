using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sahipsiz_Dostlar.Entity.Models
{
    [Table("Kullanici")]
    public partial class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adınız zorunludur")]
        public string Ad { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyadınız zorunludur")]
        public string Soyad { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telefon zorunludur")]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }

        [Display(Name = "Adres")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Adress zorunludur")]
        public string Adress { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DogumTarihi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "6 Karakterden uzun olması gerekmektedir")]
        public string Password { get; set; }
        [Display(Name = "Doğrulandı mı?")]
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
    }
}