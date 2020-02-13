using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Sessions
{
    public interface ISessionRepository
    {
        Session Add(Session session);

        IQueryable<Session> GetAll();

        Session GetById(long Id);

        bool Update(Session session);

        bool Delete(long Id);
    }
}
