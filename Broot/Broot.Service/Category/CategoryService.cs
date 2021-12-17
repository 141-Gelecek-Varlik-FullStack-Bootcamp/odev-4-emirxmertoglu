using AutoMapper;
using Broot.DB.Entities.DataContext;
using Broot.Model;
using Broot.Model.CategoryModel;

namespace Broot.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;

        public CategoryService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        // Insert Category
        public General<CategoryDetail> Insert(InsertCategory newCategory)
        {
            var result = new General<CategoryDetail>() { IsSuccess = false };
            try
            {
                var model = mapper.Map<Broot.DB.Entities.Category>(newCategory);
                using (var srv = new BrootContext())
                {
                    model.Idate = System.DateTime.Now;
                    model.IsActive = true;
                    model.Iuser = 2;

                    // Adding changes to db
                    srv.Category.Add(model);
                    srv.SaveChanges();

                    // Returning category details to entity
                    result.Entity = mapper.Map<CategoryDetail>(model);
                    result.IsSuccess = true;
                }
            }
            catch (System.Exception)
            {
                result.ExceptionMessage = "Beklenmeyen bir hata oluştu. Lütfen daha sonra tekrar deneyin!";
            }


            return result;
        }
    }
}
