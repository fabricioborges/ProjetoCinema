using Projeto_Cinema.Application.Features.Sessions.Commands;
using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Sessions
{
    public interface ISessionAppService
    {
        long Add(SessionAddCommand session);

        IQueryable<Session> GetAll();
        
        Session GetById(long Id);

        bool Update(SessionUpdateCommand session);

        bool Delete(SessionDeleteCommand session);
    }
}
