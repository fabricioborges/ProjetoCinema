using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Users.Enums
{
    public enum AccessLevelEnum : Byte
    {
        Customer = 0,
        Attendant = 1,
        Manager = 2
    }
}
