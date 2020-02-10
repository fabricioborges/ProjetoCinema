using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Managers
{
    public class Manager : Entity
    {
        public Manager()
        {
            CanAccess(AccessLevelEnum.Manager);
        }
    }
}
