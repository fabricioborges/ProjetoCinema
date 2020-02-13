using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.Snacks.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Snacks;

namespace Projeto_Cinema.Application.Features.Snacks
{
    public class SnackAppService : ISnackAppService
    {
        ISnackRepository SnackRepository;

        public SnackAppService(ISnackRepository repository)
        {
            SnackRepository = repository;
        }

        public long Add(SnackAddCommand snack)
        {
            var snackAdd = Mapper.Map<SnackAddCommand, Snack>(snack);
            var newSnack = SnackRepository.Add(snackAdd);

            return newSnack.Id;
        }

        public bool Delete(SnackDeleteCommand snack)
        {
            return SnackRepository.Delete(snack.Id);
        }

        public IQueryable<Snack> GetAll()
        {
            return SnackRepository.GetAll();
        }

        public Snack GetById(long Id)
        {
            return SnackRepository.GetById(Id);
        }

        public bool Update(SnackUpdateCommand snack)
        {
            var snackDb = SnackRepository.GetById(snack.Id);
            if (snackDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var seatEdit = Mapper.Map(snack, snackDb);

            return SnackRepository.Update(seatEdit);
        }
    }
}
