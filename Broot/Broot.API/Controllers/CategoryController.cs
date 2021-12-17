using Broot.Model;
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

        [HttpPost]
        public General<Model.CategoryModel.CategoryDetail> Insert([FromBody] Model.CategoryModel.InsertCategory newCategory)
        {
            General<Model.CategoryModel.CategoryDetail> response = new();

            response = categoryService.Insert(newCategory);

            return response;
        }
    }
}
