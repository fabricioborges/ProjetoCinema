using AutoMapper;
using Projeto_Cinema.Application.Features.Snacks.Commands;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Snacks.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SnackAddCommand, Snack>();

            CreateMap<SnackUpdateCommand, Snack>();
        }
    }
}
