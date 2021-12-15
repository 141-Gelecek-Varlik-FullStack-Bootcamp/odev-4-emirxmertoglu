using AutoMapper;
using Broot.DB.Entities.DataContext;
using Broot.Model;
using Broot.Model.ProductModel;

namespace Broot.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;

        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        public General<ProductDetail> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public General<ProductDetail> Insert(InsertProductModel newProduct)
        {
            var result = new General<ProductDetail>() { IsSuccess = false };
            try
            {
                var model = mapper.Map<Broot.DB.Entities.Product>(newProduct);
                using (var srv = new BrootContext())
                {
                    model.Idate = System.DateTime.Now;
                    model.IsActive = true;
                    model.Iuser = 2;
                    model.Name = model.DisplayName;
                    srv.Product.Add(model);
                    srv.SaveChanges();
                    result.Entity = mapper.Map<ProductDetail>(model);
                    result.IsSuccess = true;
                }
            }
            catch (System.Exception)
            {
                result.ExceptionMessage = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin!";
            }

            
            return result;
        }

        public General<ListProductModel> List()
        {
            throw new System.NotImplementedException();
        }
    }
}
