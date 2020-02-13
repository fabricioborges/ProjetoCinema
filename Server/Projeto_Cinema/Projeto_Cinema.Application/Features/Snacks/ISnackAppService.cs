using Projeto_Cinema.Application.Features.Snacks.Commands;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Snacks
{
    public interface ISnackAppService
    {
        long Add(SnackAddCommand snack);

        IQueryable<Snack> GetAll();

        Snack GetById(long Id);

        bool Update(SnackUpdateCommand snack);

        bool Delete(SnackDeleteCommand snack);
    }
}
