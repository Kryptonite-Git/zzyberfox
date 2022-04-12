using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Commands;
using User.Application.Responses;

namespace User.Application.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User.Core.Entities.User, UserResponse>().ReverseMap();
            CreateMap<User.Core.Entities.User, CreateUserCommand>().ReverseMap();
        }
    }
}
