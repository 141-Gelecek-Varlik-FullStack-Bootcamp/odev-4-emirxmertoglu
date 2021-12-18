using System.ComponentModel.DataAnnotations;

namespace Broot.Model.CategoryModel
{
    public class InsertCategory
    {
        [Required(ErrorMessage ="Kategorinin temsili adini giriniz!")]
        [MaxLength(50, ErrorMessage ="Kategorinin temsili adi max 50 karakter olabilir!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Kategorinin adini giriniz!")]
        [MaxLength(50, ErrorMessage = "Kategorinin adi max 50 karakter olabilir!")]
        public string DisplayName { get; set; }
    }
}
