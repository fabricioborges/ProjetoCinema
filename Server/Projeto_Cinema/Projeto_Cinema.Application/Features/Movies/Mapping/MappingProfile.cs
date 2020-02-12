using AutoMapper;
using Projeto_Cinema.Application.Features.Movies.Commands;
using Projeto_Cinema.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Movies.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieAddCommand, Movie>();

            CreateMap<MovieUpdateCommand, Movie>();
        }
    }
}
