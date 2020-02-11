using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Sessions;
using System;

namespace Projeto_Cinema.Domain.Tests.Features.Sessions
{
    [TestFixture]
    public class SessionDomainTests
    {
        Session _session;

        [SetUp]
        public void SetUp()
        {
            _session = ObjectMother.sessionDefault;
        }

        [Test]
        public void Nao_deveria_remover_uma_sessao_a_menos_de_10_dias_da_data()
        {
            //Action
            var canRemove = _session.CanRemove();

            //Assert
            canRemove.Should().BeFalse();
        }

        [Test]
        public void Deveria_remover_uma_sessao_com_10_dias_ou_mais_antes_da_data()
        {
            //Arrange
            _session.Date = DateTime.Now.AddDays(-10);
            
            //Action
            var canRemove = _session.CanRemove();

            //Assert
            canRemove.Should().BeTrue();
        }
    }
}
