using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Tests.Features.Tickets
{
    [TestFixture]
    public class TicketDomainTests
    {
        Ticket _ticket;

        [SetUp]
        public void SetUp()
        {
            _ticket = ObjectMother.ticketDefault;
            ObjectMother.seatListDefault.Clear();
        }

        [Test]
        public void Dominio_Deveria_calcular_o_valor_dos_assentos_do_ticket()
        {
            //Arrange
            ObjectMother.CreateListOfSeats(2);
            var target = 20;
            _ticket.MovieTheater.Seats = ObjectMother.seatListDefault;

            //Action
            var result = _ticket.CalculateValueSeats();

            //Assert
            result.Should().Be(target);
        }

        [Test]
        public void Dominio_Deveria_calcular_o_valor_dos_lanches_do_ticket()
        {
            //Arrange
            var target = 31.5;
            _ticket.Snacks = ObjectMother.snackListDefault;

            //Action
            var result = _ticket.CalculateValueSnacks();
                        
            //Assert
            result.Should().Be(target);
        }

        [Test]
        public void Dominio_Deveria_calcular_o_valor_total_do_ticket()
        {
            //Arrange
            _ticket.Snacks = ObjectMother.snackListDefault;
            ObjectMother.CreateListOfSeats(2);
            _ticket.MovieTheater.Seats = ObjectMother.seatListDefault;
            var targetSnacks = 31.5;
            var targetSeats = 20;
            var targetTotal = 51.5;

            //Action
            var resultSnacks = _ticket.CalculateValueSnacks();
            var resultSeats = _ticket.CalculateValueSeats();
            var resultTotal = resultSnacks + resultSeats;
                        
            //Assert
            resultSeats.Should().Be(targetSeats);
            resultSnacks.Should().Be(targetSnacks);
            resultTotal.Should().Be(targetTotal);
        }

        [Test]
        public void Deveria_confirmar_o_ticket()
        {
            //Action
            _ticket.ConfirmTicket(true);

            //Assert
            _ticket.IsConfirmed.Should().BeTrue();
        }

        [Test]
        public void Dominio_Nao_deveria_confirmar_o_ticket()
        {
            //Action
            _ticket.ConfirmTicket(false);

            //Assert
            _ticket.IsConfirmed.Should().BeFalse();
        }
    }
}
