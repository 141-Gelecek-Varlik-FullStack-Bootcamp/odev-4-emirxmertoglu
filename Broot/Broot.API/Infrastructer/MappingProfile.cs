﻿using AutoMapper;

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
        }
    }
}
