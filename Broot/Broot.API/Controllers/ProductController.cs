using Broot.Model;
using Broot.Model.ProductModel;
using Broot.Service.Product;
using Microsoft.AspNetCore.Mvc;

namespace Broot.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        // Insert Product
        [HttpPost]
        public General<ProductDetail> Insert([FromBody] InsertProductModel newProduct)
        {
            return productService.Insert(newProduct);
        }

        // Get Products
        [HttpGet]
        public General<ListProductModel> GetList()
        {
            return productService.List();
        }

        // Get Product by Id
        [HttpGet("{id}")]
        public General<ProductDetail> GetById(int id)
        {
            return productService.GetById(id);
        }

        // Update Product
        [HttpPut("{id}")]
        public General<ProductDetail> Update([FromBody] InsertProductModel updatedProduct, int id, int updater)
        {
            return productService.Update(updatedProduct, id, updater);
        }

        // Delete Product
        [HttpDelete("{id}")]
        public General<ProductDetail> Delete(int id, int updater)
        {
            return productService.Delete(id, updater);
        }

        // Sort Products
        [HttpGet("Sort")]
        public General<ListProductModel> Sort([FromQuery] string sortBy)
        {
            return productService.Sort(sortBy);
        }

        // Filter Products
        [HttpGet("Filter")]
        public General<ListProductModel> Filter([FromQuery] string filterBy)
        {
            return productService.Filter(filterBy);
        }

        // Paging Products
        [HttpGet("Paging")]
        public General<ListProductModel> Paging([FromQuery] int productNumberPerPage, [FromQuery] int currentPage)
        {
            return productService.Paging(productNumberPerPage, currentPage);
        }

        // Apply All Filters to Products
        [HttpGet("AllFilters")]
        public General<ListProductModel> AllFilters([FromQuery] string sortBy, [FromQuery] string filterBy, [FromQuery] int productNumberPerPage, [FromQuery] int currentPage)
        {
            return productService.AllFilters(sortBy, filterBy, productNumberPerPage, currentPage);
        }

    }
}
