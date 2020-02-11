using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Attendants;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using System;

namespace Projeto_Cinema.Domain.Tests.Features.Attendants
{
    [TestFixture]
    public class AttendantDomainTests
    {
        Attendant _attendant;

        [SetUp]
        public void SetUp()
        {
            _attendant = ObjectMother.attendantDefault;
        }

        [Test]
        public void Deveria_validar_campos_obrigatorios_do_attendant()
        {
            //Action
            Action validate = () => _attendant.Validate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Deveria_retornar_excessao_ao_ter_campos_nulos()
        {
            //Arrange
            _attendant.Name = string.Empty;

            //Action
            Action validate = () => _attendant.Validate();

            //Assert
            validate.Should().Throw<AttendantException>();
        }
    }
}
