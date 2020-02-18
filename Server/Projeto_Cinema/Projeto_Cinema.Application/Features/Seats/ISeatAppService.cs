using Projeto_Cinema.Application.Features.Seats.Commands;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Seats
{
    public interface ISeatAppService
    {
        long Add(SeatAddCommand seat);

        IQueryable<Seat> GetAll();

        Seat GetById(long Id);

        bool Update(List<SeatUpdateCommand> seat);

        bool Delete(SeatDeleteCommand seat);
    }
}
