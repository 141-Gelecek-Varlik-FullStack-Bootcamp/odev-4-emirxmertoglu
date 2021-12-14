using System.ComponentModel.DataAnnotations;

namespace Broot.Model.UserModel
{
    public class UserLoginModel : IUserModel
    {
        [Required(ErrorMessage = "Kullanici adinizi giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Sifrenizi giriniz!")]
        public string Password { get; set; }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
