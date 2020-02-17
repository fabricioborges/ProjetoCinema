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
        public void Dominio_Nao_deveria_remover_uma_sessao_a_menos_de_10_dias_da_data()
        {
            //Action
            var canRemove = _session.CanRemove();

            //Assert
            canRemove.Should().BeFalse();
        }

        [Test]
        public void Dominio_Deveria_remover_uma_sessao_com_10_dias_ou_mais_antes_da_data()
        {
            //Arrange
            _session.DateInitial = DateTime.Now.AddDays(-10);

            //Action
            var canRemove = _session.CanRemove();

            //Assert
            canRemove.Should().BeTrue();
        }

        [Test]
        public void Dominio_Deveria_calcular_a_duracao_da_sessao()
        {
            //Arrange
            var duration = TimeSpan.FromHours(1);
            duration += TimeSpan.FromMinutes(40);
            duration += TimeSpan.FromSeconds(30);
            var targetDuration = duration;

            //Action
            _session.SetDuration();

            //Assert
            _session.Duration.Should().Be(targetDuration);
        }

        [Test]
        public void Dominio_Deveria_calcular_a_data_final_da_sessao()
        {
            //Arrange

            var targetDateFinal = _session.Movie.EndDate;

            //Action
            _session.SetEndDate();

            //Assert
            _session.EndDate.Should().Be(targetDateFinal);
        }
    }
}
