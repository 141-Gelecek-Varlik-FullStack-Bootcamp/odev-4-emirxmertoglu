using Broot.Model;
using Broot.Model.ProductModel;

namespace Broot.Service.Product
{
    public interface IProductService
    {
        // List Products
        public General<ListProductModel> List();

        // Insert Product
        public General<ProductDetail> Insert(InsertProductModel newProduct);

        // Get Product by Id
        public General<ProductDetail> GetById(int id);

        // Update Product
        public General<ProductDetail> Update(InsertProductModel updatedProduct, int id, int updater);

        // Delete Product
        public General<ProductDetail> Delete(int id, int updater);

        // Sort Products
        public General<ListProductModel> Sort(string sortBy);

    }
}
