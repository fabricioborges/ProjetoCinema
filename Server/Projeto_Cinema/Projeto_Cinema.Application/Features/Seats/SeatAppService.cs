using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Projeto_Cinema.Application.Features.Seats.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Seats;

namespace Projeto_Cinema.Application.Features.Seats
{
    public class SeatAppService : ISeatAppService
    {
        ISeatRepository SeatRepository;

        public SeatAppService(ISeatRepository repository)
        {
            SeatRepository = repository;
        }

        public long Add(SeatAddCommand seat)
        {
            var seatAdd = Mapper.Map<SeatAddCommand, Seat>(seat);
            var newSeat = SeatRepository.Add(seatAdd);

            return newSeat.Id;
        }

        public bool Delete(SeatDeleteCommand seat)
        {
            return SeatRepository.Delete(seat.Id);
        }

        public IQueryable<Seat> GetAll()
        {
            return SeatRepository.GetAll();
        }

        public Seat GetById(long Id)
        {
            return SeatRepository.GetById(Id);
        }

        public bool Update(List<SeatUpdateCommand> seat)
        {
            var ids = seat.Select(x => x.Id).ToList();

            var seatDb = SeatRepository.GetBySeatIds(ids).ToList();
            if (seatDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var seatEdit = Mapper.Map(seat, seatDb);
            foreach (var item in seatEdit)
            {
                SeatRepository.Update(item);
            }


            return true;
        }
    }
}
