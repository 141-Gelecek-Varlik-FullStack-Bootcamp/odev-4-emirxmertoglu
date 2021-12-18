using Broot.Model;
using Broot.Model.CategoryModel;
using Broot.Service.Category;
using Microsoft.AspNetCore.Mvc;

namespace Broot.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        // Insert Category
        [HttpPost]
        public General<CategoryDetail> Insert([FromBody] InsertCategory newCategory)
        {
            General<CategoryDetail> response = new();

            response = categoryService.Insert(newCategory);

            return response;
        }

        // Update Category
        [HttpPut("{id}")]
        public General<CategoryDetail> Uptade([FromBody] InsertCategory updatedCategory, int id, int updater)
        {
            return categoryService.Uptade(updatedCategory, id, updater);
        }

        // Delete Category
        [HttpDelete("{id}")]
        public General<CategoryDetail> Delete(int id, int updater)
        {
            return categoryService.Delete(id, updater);
        }

        // Get All Categories
        [HttpGet]
        public General<CategoryDetail> Get()
        {
            return categoryService.Get();
        }


    }
}
