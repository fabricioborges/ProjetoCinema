using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Infra.ORM.Features.Seats;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.Seats
{
    [TestFixture]
    public class SeatRepositoryTests : EffortTestBase
    {
        FakeDbContext Context;
        SeatRepository _repository;
        Seat _seat;
        Seat _seatSeed;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new SeatRepository(Context);
            _seat = ObjectMother.seatDefault;

            _seatSeed = ObjectMother.seatDefault;

            Context.Seats.Add(_seatSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_Seat_deveria_gravar_um_novo_assento()
        {
            //Arrange
            Seat result = _repository.Add(_seat);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Seat_deveria_retornar_um_assento()
        {
            //Arrange
            Seat seat = _repository.Add(_seat);

            //Action
            Seat result = _repository.GetById(seat.Id);

            //Assert
            result.Number.Should().Be(seat.Number);
            result.Id.Should().Be(seat.Id);
        }



        [Test]
        public void Repository_Seat_deveria_alterar_um_novo_assento()
        {
            //Arrange
            Seat newSeat = _repository.Add(_seat);
            newSeat.Number = 5;

            //Action
            _repository.Update(newSeat);

            //Assert
            Seat result = _repository.GetById(newSeat.Id);
            result.Number.Should().Be(newSeat.Number);
        }

        [Test]
        public void Repository_Seat_deveria_deletar_um_assento()
        {
            //Arrange
            Seat newSeat = _repository.Add(_seat);

            //Action
            _repository.Delete(newSeat.Id);

            //Assert
            Seat result = _repository.GetById(newSeat.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_Seat_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_Seat_deveria_buscar_todos_os_assentos()
        {
            //Action
            var seats = _repository.GetAll().ToList();

            //Assert
            seats.Should().NotBeNull();
            seats.Should().HaveCount(Context.Seats.Count());
            seats.First().Should().Be(_seatSeed);

        }
    }
}
