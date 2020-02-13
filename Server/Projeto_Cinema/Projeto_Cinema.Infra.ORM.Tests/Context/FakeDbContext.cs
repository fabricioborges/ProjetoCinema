using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Context
{
    public class FakeDbContext : ProjetoCinemaContext
    {
        public FakeDbContext(DbConnection connection) : base(connection)
        {

        }
    }
}
