using Broot.Model;
using Broot.Model.ProductModel;

namespace Broot.Service.Product
{
    public interface IProductService
    {
        public General<ListProductModel> List();
        public General<ProductDetail> Insert(InsertProductModel newProduct);
        public General<ProductDetail> GetById(int id);
    }
}
