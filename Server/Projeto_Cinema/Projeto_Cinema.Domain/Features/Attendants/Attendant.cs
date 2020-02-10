using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Enums;

namespace Projeto_Cinema.Domain.Features.Attendants
{
    public class Attendant : Entity
    {
        public Attendant()
        {
            CanAccess(AccessLevelEnum.Attendant);
        }
    }
}
