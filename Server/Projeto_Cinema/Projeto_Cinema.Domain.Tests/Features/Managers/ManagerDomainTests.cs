using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Managers;
using System;

namespace Projeto_Cinema.Domain.Tests.Features.Managers
{
    [TestFixture]
    public class ManagerDomainTests
    {
        Manager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = ObjectMother.managerDefault;
        }

        [Test]
        public void Deveria_validar_campos_obrigatorios_do_manager()
        {
            //Action
            Action validate = () => _manager.Validate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Deveria_retornar_excessao_ao_ter_campos_nulos()
        {
            //Arrange
            _manager.Name = string.Empty;

            //Action
            Action validate = () => _manager.Validate();

            //Assert
            validate.Should().Throw<ManagerException>();
        }
    }
}
