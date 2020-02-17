using AutoMapper;
using Projeto_Cinema.Application.Features.MoviesTheaters.Commands;
using Projeto_Cinema.Application.Features.MoviesTheaters.ViewModels;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.MoviesTheaters.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieTheaterAddCommand, MovieTheater>();
                ;

            CreateMap<MovieTheaterUpdateCommand, MovieTheater>()
                .ForPath(src => src.Seats, m => m.MapFrom(dest => dest.Seats));

            CreateMap<MovieTheater, MovieTheaterViewModel>()
                .ForPath(src => src.Seats, m => m.MapFrom(dest => dest.Seats));
        }
    }
}
