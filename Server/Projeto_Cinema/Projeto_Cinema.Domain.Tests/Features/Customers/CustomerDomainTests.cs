using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Tests.Features.Customers
{
    [TestFixture]
    public class CustomerDomainTests
    {
        Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = ObjectMother.customerDefault;
        }

        [Test]
        public void Deveria_validar_campos_obrigatorios_do_customer()
        {
            //Action
            Action validate = () => _customer.Validate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Deveria_retornar_excessao_ao_ter_campos_nulos()
        {
            //Arrange
            _customer.Name = string.Empty;

            //Action
            Action validate = () => _customer.Validate();

            //Assert
            validate.Should().Throw<CustomerException>();
        }

    }
}
