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
                .ForMember(c => c.DateInitial, x => x.MapFrom(y => y.DateInitial))
                .ForMember(c => c.EndDate, x => x.MapFrom(y => y.EndDate));

            CreateMap<Session, SessionViewModel>();
        }
    }
}
