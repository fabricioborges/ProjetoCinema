using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.Sessions
{
    public class SessionRepository : ISessionRepository
    {
        ProjetoCinemaContext Context;

        public SessionRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public Session Add(Session session)
        {
            Context.Sessions.Add(session);
            Context.SaveChanges();
            return session;
        }

        public bool Delete(long Id)
        {
            var session = Context.Sessions.Where(c => c.Id == Id).FirstOrDefault();
            if (session == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(session).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Session> GetAll()
        {
            return Context.Sessions;
        }

        public Session GetById(long Id)
        {
            return Context.Sessions.FirstOrDefault(s => s.Id == Id);
        }

        public bool Update(Session session)
        {
            Context.Entry(session).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
