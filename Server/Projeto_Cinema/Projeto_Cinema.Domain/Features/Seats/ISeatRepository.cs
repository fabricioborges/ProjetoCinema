using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Seats
{
    public interface ISeatRepository
    {
        Seat Add(Seat seat);

        IQueryable<Seat> GetAll();

        Seat GetById(long Id);

        bool Update(Seat seat);

        bool Delete(long Id);
    }
}
