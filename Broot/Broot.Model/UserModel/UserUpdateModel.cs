using System;
using System.ComponentModel.DataAnnotations;

namespace Broot.Model.UserModel
{
    public class UserUpdateModel : IUserModel
    {
        [Required(ErrorMessage = "Adinizi giriniz!")]
        [MaxLength(50, ErrorMessage = "Adiniz max 50 karakter olabilir!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kullanici adinizi giriniz!")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Kullanici adiniz min 3 ve max 50 karakterden olusabilir!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email adresinizi giriniz!")]
        [EmailAddress(ErrorMessage = "Gecerli bir mail adresi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Sifrenizi giriniz!")]
        public string Password { get; set; }
    }
}
