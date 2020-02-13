using AutoMapper;
using Projeto_Cinema.Application.Features.Tickets.Commands;
using Projeto_Cinema.Domain.Features.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Tickets.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketAddCommand, Ticket>()
                .ForPath(src => src.User, m => m.MapFrom(dest => dest.User))
                .ForPath(src => src.Movie, m => m.MapFrom(dest => dest.Movie))
                .ForPath(src => src.MovieTheater, m => m.MapFrom(dest => dest.MovieTheater))
                .ForPath(src => src.Session, m => m.MapFrom(dest => dest.Session))
                .ForPath(src => src.Snacks, m => m.MapFrom(dest => dest.Snacks));

            CreateMap<TicketUpdateCommand, Ticket>()
                .ForPath(src => src.User, m => m.MapFrom(dest => dest.User))
                .ForPath(src => src.Movie, m => m.MapFrom(dest => dest.Movie))
                .ForPath(src => src.MovieTheater, m => m.MapFrom(dest => dest.MovieTheater))
                .ForPath(src => src.Session, m => m.MapFrom(dest => dest.Session))
                .ForPath(src => src.Snacks, m => m.MapFrom(dest => dest.Snacks));
        }
    }
}
