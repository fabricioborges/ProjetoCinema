using Projeto_Cinema.Domain.Features.Attendants;
using Projeto_Cinema.Domain.Features.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Attendant attendantDefault
        {
            get
            {
                return new Attendant()
                {
                    Name = "Attendant",
                    Email = "attendant@attendat.com",
                    Password = "password"
                };
            }
        }
    }
}
