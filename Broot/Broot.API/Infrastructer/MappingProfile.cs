using AutoMapper;
using Broot.Model.CategoryModel;
using Broot.Model.ProductModel;

namespace Broot.API.Infrastructer
{
    public class MappingProfile : Profile
    {
        // Creating constructer
        public MappingProfile()
        {
            // Create user.
            CreateMap<Broot.Model.UserModel.UserCreateModel, Broot.DB.Entities.User>();
            CreateMap<Broot.DB.Entities.User, Broot.Model.UserModel.UserCreateModel>();

            // Login user.
            CreateMap<Broot.Model.UserModel.UserLoginModel, Broot.DB.Entities.User>();
            CreateMap<Broot.DB.Entities.User, Broot.Model.UserModel.UserLoginModel>();

            // Update user.
            CreateMap<Broot.Model.UserModel.UserUpdateModel, Broot.DB.Entities.User>();
            CreateMap<Broot.DB.Entities.User, Broot.Model.UserModel.UserUpdateModel>();

            // Delete user.
            CreateMap<Broot.Model.UserModel.UserDeleteModel, Broot.DB.Entities.User>();
            CreateMap<Broot.DB.Entities.User, Broot.Model.UserModel.UserDeleteModel>();

            // Get users.
            CreateMap<Broot.Model.UserModel.UserGetModel, Broot.DB.Entities.User>();
            CreateMap<Broot.DB.Entities.User, Broot.Model.UserModel.UserGetModel>();

            // Product
            CreateMap<InsertProductModel, Broot.DB.Entities.Product>();
            CreateMap<Broot.DB.Entities.Product, ProductDetail>();
            CreateMap<Broot.DB.Entities.Product, ListProductModel>();

            //Category
            CreateMap<InsertCategory, Broot.DB.Entities.Category>();
            CreateMap<Broot.DB.Entities.Category, CategoryDetail>();

        }
    }
}
