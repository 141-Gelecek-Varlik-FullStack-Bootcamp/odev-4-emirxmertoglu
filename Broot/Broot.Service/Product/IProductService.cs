using Broot.Model;
using Broot.Model.ProductModel;

namespace Broot.Service.Product
{
    public interface IProductService
    {
        // List products
        public General<ListProductModel> List();

        // Insert product
        public General<ProductDetail> Insert(InsertProductModel newProduct);

        // Get product by id
        public General<ProductDetail> GetById(int id);
    }
}
