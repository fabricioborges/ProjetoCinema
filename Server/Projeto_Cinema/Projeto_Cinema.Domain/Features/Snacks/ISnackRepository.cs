using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Snacks
{
    public interface ISnackRepository
    {
        Snack Add(Snack snack);

        IQueryable<Snack> GetAll();

        Snack GetById(long Id);

        bool Update(Snack snack);

        bool Delete(long Id);
    }
}
