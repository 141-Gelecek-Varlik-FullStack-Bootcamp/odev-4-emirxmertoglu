using System.ComponentModel.DataAnnotations;

namespace Broot.Model.CategoryModel
{
    public class InsertCategory
    {
        [Required(ErrorMessage ="Kategorinin temsili adini giriniz!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Kategorinin adini giriniz!")]
        public string DisplayName { get; set; }
    }
}
