using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.Snacks
{
    public class SnackRepository : ISnackRepository
    {
        ProjetoCinemaContext Context;

        public SnackRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public Snack Add(Snack snack)
        {
            Context.Snacks.Add(snack);
            Context.SaveChanges();
            return snack;
        }

        public bool Delete(long Id)
        {
            var snack = Context.Snacks.Where(c => c.Id == Id).FirstOrDefault();
            if (snack == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(snack).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<Snack> GetAll()
        {
            return Context.Snacks;
        }

        public Snack GetById(long Id)
        {
            return Context.Snacks.FirstOrDefault(s => s.Id == Id);
        }

        public List<Snack> GetById(List<long> Id)
        {
            return Context.Snacks.Where(x => Id.Contains(x.Id)).ToList();
        }

        public bool Update(Snack snack)
        {
            Context.Entry(snack).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
