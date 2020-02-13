using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Tickets;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.Tickets
{
    [TestFixture]
    public class TicketAppServiceTests : TestBase
    {
        Mock<ITicketRepository> _repository;
        TicketAppService _appService;
        
        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<ITicketRepository>();
            _appService = new TicketAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Ticket_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var ticket = ObjectMother.ticketDefault;
            ticket.Id = expectedId;
            var ticketAddCommand = ObjectMother.ticketAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Ticket>())).Returns(ticket);

            //Action
            var result = _appService.Add(ticketAddCommand);

            //Assert
            result.Should().Be((int)ticket.Id);
            _repository.Verify(x => x.Add(It.IsAny<Ticket>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Ticket_deveria_deletar_ticket()
        {
            //Arrange
            var ticket = ObjectMother.ticketDeleteCommand;

            _repository.Setup(x => x.Delete(ticket.Id)).Returns(true);

            //Action
            var ticketDeleteAction = _appService.Delete(ticket);

            //Assert
            ticketDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(ticket.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Ticket_nao_deveria_deletar_ticket()
        {
            //Arrange
            var ticket = ObjectMother.ticketDeleteCommand;

            _repository.Setup(x => x.Delete(ticket.Id)).Returns(false);

            //Action
            var ticketDeleteAction = _appService.Delete(ticket);

            //Assert
            ticketDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(ticket.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Ticket_deveria_atualizar_ticket()
        {
            //Arrange
            var ticket = ObjectMother.ticketDefault;
            var ticketCmd = ObjectMother.ticketUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(ticketCmd.Id)).Returns(ticket);
            _repository.Setup(pr => pr.Update(ticket)).Returns(updated);

            //Action
            var ticketUpdated = _appService.Update(ticketCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(ticketCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(ticket), Times.Once);
            ticketUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Ticket_deveria_retornar_excecao()
        {
            //Arrange
            var ticketCmd = ObjectMother.ticketUpdateCommand;
            _repository.Setup(x => x.GetById(ticketCmd.Id)).Returns((Ticket)null);

            //Action
            Action act = () => _appService.Update(ticketCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(ticketCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Ticket>()), Times.Never);
        }

        [Test]
        public void ApplService_Ticket_deveria_retornar_ticket()
        {
            //Arrange
            Ticket user = ObjectMother.ticketDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(user);

            //Action
            Ticket ticketResult = _appService.GetById(user.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            ticketResult.Should().NotBeNull();
            ticketResult.Id.Should().Be(user.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Ticket_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Ticket> ticketList = ObjectMother.ticketListDefault;
            _repository.Setup(x => x.GetAll()).Returns(ticketList);

            //Action
            List<Ticket> ticketResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            ticketResultList.Should().NotBeNull();
            ticketResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }

    }
}
