using Broot.Model;
using Broot.Model.CategoryModel;

namespace Broot.Service.Category
{
    public interface ICategoryService
    {
        // Insert category
        public General<CategoryDetail> Insert(InsertCategory newCategory);

    }
}
