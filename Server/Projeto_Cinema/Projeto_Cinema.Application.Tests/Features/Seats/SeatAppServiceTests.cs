using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Seats;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.Seats
{
    [TestFixture]
    public class SeatAppServiceTests : TestBase
    {
        Mock<ISeatRepository> _repository;
        SeatAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<ISeatRepository>();
            _appService = new SeatAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Seat_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var seat = ObjectMother.seatDefault;
            seat.Id = expectedId;
            var seatAddCommand = ObjectMother.seatAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Seat>())).Returns(seat);

            //Action
            var result = _appService.Add(seatAddCommand);

            //Assert
            result.Should().Be((int)seat.Id);
            _repository.Verify(x => x.Add(It.IsAny<Seat>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Seat_deveria_deletar_assento()
        {
            //Arrange
            var seat = ObjectMother.seatDeleteCommand;

            _repository.Setup(x => x.Delete(seat.Id)).Returns(true);

            //Action
            var seatDeleteAction = _appService.Delete(seat);

            //Assert
            seatDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(seat.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Seat_nao_deveria_deletar_assento()
        {
            //Arrange
            var seat = ObjectMother.seatDeleteCommand;

            _repository.Setup(x => x.Delete(seat.Id)).Returns(false);

            //Action
            var seatDeleteAction = _appService.Delete(seat);

            //Assert
            seatDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(seat.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Seat_deveria_atualizar_assento()
        {
            //Arrange
            var seat = ObjectMother.seatDefault;
            var seatCmd = ObjectMother.seatUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(seatCmd.Id)).Returns(seat);
            _repository.Setup(pr => pr.Update(seat)).Returns(updated);

            //Action
            var seatUpdated = _appService.Update(seatCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(seatCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(seat), Times.Once);
            seatUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Seat_deveria_retornar_excecao()
        {
            //Arrange
            var seatCmd = ObjectMother.seatUpdateCommand;
            _repository.Setup(x => x.GetById(seatCmd.Id)).Returns((Seat)null);

            //Action
            Action act = () => _appService.Update(seatCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(seatCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Seat>()), Times.Never);
        }

        [Test]
        public void ApplService_Seat_deveria_retornar_assento()
        {
            //Arrange
            Seat user = ObjectMother.seatDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(user);

            //Action
            Seat userResult = _appService.GetById(user.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            userResult.Should().NotBeNull();
            userResult.Id.Should().Be(user.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Seat_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            ObjectMother.CreateListOfSeats(100);
            IQueryable<Seat> seatList = ObjectMother.seatListDefault.AsQueryable();
            _repository.Setup(x => x.GetAll()).Returns(seatList);

            //Action
            List<Seat> seatResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            seatResultList.Should().NotBeNull();
            seatResultList.Should().HaveCount(100);
            _repository.VerifyNoOtherCalls();
        }
    }
}
