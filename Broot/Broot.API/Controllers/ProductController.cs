using Broot.API.Infrastructer;
using Broot.Model;
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

        [HttpPost]
        public General<Model.ProductModel.ProductDetail> Insert([FromBody] Model.ProductModel.InsertProductModel newProduct)
        {
            General<Model.ProductModel.ProductDetail> response = new();

            response = productService.Insert(newProduct);

            return response;
        }

        [HttpGet]
        public General<Model.ProductModel.ListProductModel> GetList()
        {
            General<Model.ProductModel.ListProductModel> response = new();
            return response;
        }

        [HttpGet("{id}")]
        public General<Model.ProductModel.ProductDetail> GetById(int id)
        {
            return productService.GetById(id);
        }
    }
}
