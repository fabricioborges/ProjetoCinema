using AutoMapper;
using Projeto_Cinema.Application.Features.Sessions.Commands;
using Projeto_Cinema.Application.Features.Sessions.ViewModels;
using Projeto_Cinema.Domain.Features.Sessions;

namespace Projeto_Cinema.Application.Features.Sessions.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SessionAddCommand, Session>();                

            CreateMap<SessionUpdateCommand, Session>()
                .ForPath(src => src.Movie, m => m.MapFrom(dest => dest.Movie))
                .ForPath(src => src.MovieTheater, m => m.MapFrom(dest => dest.MovieTheater));

            CreateMap<Session, SessionViewModel>();
        }
    }
}
