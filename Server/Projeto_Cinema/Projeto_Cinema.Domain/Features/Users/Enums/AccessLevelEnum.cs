using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Users.Enums
{
    public enum AccessLevelEnum : Byte
    {
        Customer = 1,
        Attendant = 2,
        Manager = 3
    }
}
