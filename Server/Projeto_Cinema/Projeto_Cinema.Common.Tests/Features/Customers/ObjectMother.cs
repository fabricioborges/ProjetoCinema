using Projeto_Cinema.Domain.Features.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Customer customerDafault
        {
            get
            {
                return new Customer()
                {
                    Name = "Customer",
                    Email = "customer@customer.com",
                    Password = "password",
                    Snacks = snackListDefault,
                     
                };
            }
        }
    }
}
