using AutoMapper;
using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Application.Features.Users.ViewModels;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Users.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAddCommand, User>();

            CreateMap<UserUpdateCommand, User>();

            CreateMap<User, UserViewModel>();
        }
    }
}
