using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Context
{
    public class DbContextFactory : IDbContextFactory<ProjetoCinemaContext>
    {
        public ProjetoCinemaContext Create()
        {
            return new ProjetoCinemaContext();
        }
    }
}
