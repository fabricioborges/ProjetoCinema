using AutoMapper;
using Projeto_Cinema.Application.Features.Seats.Commands;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Seats.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SeatAddCommand, Seat>();

            CreateMap<SeatUpdateCommand, Seat>();
        }
    }
}
