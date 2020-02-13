using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Tickets;
using Projeto_Cinema.Infra.ORM.Features.Tickets;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Linq;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.Tickets
{
    [TestFixture]
    public class TicketRepositoryTests : EffortTestBase
    {
        FakeDbContext Context;
        TicketRepository _repository;
        Ticket _ticket;
        Ticket _ticketSeed;


        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new TicketRepository(Context);
            _ticket = ObjectMother.ticketToPersist;

            _ticketSeed = ObjectMother.ticketToPersist;

            Context.Tickets.Add(_ticketSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_Ticket_deveria_gravar_um_novo_ticket()
        {
            //Arrange
            Ticket result = _repository.Add(_ticket);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Ticket_deveria_retornar_um_ticket()
        {
            //Arrange
            Ticket ticket = _repository.Add(_ticket);

            //Action
            Ticket result = _repository.GetById(ticket.Id);

            //Assert
            result.Value.Should().Be(ticket.Value);
            result.Id.Should().Be(ticket.Id);
        }



        [Test]
        public void Repository_Ticket_deveria_alterar_um_novo_ticket()
        {
            //Arrange
            Ticket newTicket = _repository.Add(_ticket);
            newTicket.Value = 10;

            //Action
            _repository.Update(newTicket);

            //Assert
            Ticket result = _repository.GetById(newTicket.Id);
            result.Value.Should().Be(newTicket.Value);
        }

        [Test]
        public void Repository_Ticket_deveria_deletar_um_ticket()
        {
            //Arrange
            Ticket newTicket = _repository.Add(_ticket);

            //Action
            _repository.Delete(newTicket.Id);

            //Assert
            Ticket result = _repository.GetById(newTicket.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_Ticket_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_Ticket_deveria_buscar_todos_os_Tickets()
        {
            //Action
            var tickets = _repository.GetAll().ToList();

            //Assert
            tickets.Should().NotBeNull();
            tickets.Should().HaveCount(Context.Tickets.Count());
            tickets.First().Should().Be(_ticketSeed);

        }
    }
}
