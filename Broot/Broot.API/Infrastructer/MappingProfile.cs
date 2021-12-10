using AutoMapper;

namespace Broot.API.Infrastructer
{
    public class MappingProfile : Profile
    {
        // Creating constructer
        public MappingProfile()
        {
            CreateMap<Broot.Model.UserModel.User, Broot.DB.Entities.User>();
            CreateMap<Broot.DB.Entities.User, Broot.Model.UserModel.User>();
        }
    }
}
