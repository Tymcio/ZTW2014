using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WnioskiOnline.Models
{

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "Login")]
        [MaxLength(40)]
        [StringLength(40, ErrorMessage = "Login nie może mieć więcej niż 40 znaków.")]
        public string UserName { get; set; }

        [Display(Name = "Imię")]
        [MaxLength(40)]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        [MaxLength(40)]
        public string Nazwisko { get; set; }

        [Display(Name = "Email")]
        [MaxLength(40)]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [MaxLength(15)]
        public string Telefon { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Obecne hasło")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi składać się z co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Podane hasła różnią się.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętać hasło?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Imię")]
        [StringLength(40, ErrorMessage = "Imię nie może mieć więcej niż 40 znaków.")]
        public string Imie { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        [StringLength(40, ErrorMessage = "Nazwisko nie może mieć więcej niż 40 znaków.")]
        public string Nazwisko { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [StringLength(40, ErrorMessage = "Adres email nie może mieć więcej niż 40 znaków.")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "{0} musi składać się co najmniej z {2} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła różnią się.")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Telefon")]
        [StringLength(15, ErrorMessage = "Telefon nie może mieć więcej niż 15 znaków.")]
        public string Telefon { get; set; }

        [Display(Name = "Rola")]
        public string Rola { get; set; }

    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
