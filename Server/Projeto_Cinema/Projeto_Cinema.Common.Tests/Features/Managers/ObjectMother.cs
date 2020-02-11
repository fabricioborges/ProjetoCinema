using Projeto_Cinema.Domain.Features.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Manager managerDefault
        {
            get
            {
                return new Manager()
                {
                    Name = "manager",
                    Email = "email@email.com",
                    Password = "password"
                };
            }
        }
    }
}
