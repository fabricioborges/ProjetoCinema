using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Movies;
using Projeto_Cinema.Application.Features.MoviesTheaters;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.MovieTheaters
{
    [TestFixture]
    public class MovieTheaterAppServiceTests : TestBase
    {
        Mock<IMovieTheaterRepository> _repository;
        Mock<ISeatRepository> _seatRepository;

        MovieTheatersAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IMovieTheaterRepository>();
            _seatRepository = new Mock<ISeatRepository>();
            _appService = new MovieTheatersAppService(_repository.Object, _seatRepository.Object);
        }

        [Test]
        public void ApplService_MovieTheater_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var movieTheater = ObjectMother.movieTheaterDefault;
            movieTheater.Id = expectedId;
            var movieTheaterAddCommand = ObjectMother.movieTheaterAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<MovieTheater>())).Returns(movieTheater);

            //Action
            var result = _appService.Add(movieTheaterAddCommand);

            //Assert
            result.Should().Be((int)movieTheater.Id);
            _repository.Verify(x => x.Add(It.IsAny<MovieTheater>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_MovieTheater_deveria_deletar_sala_de_cinema()
        {
            //Arrange
            var movieTheater = ObjectMother.movieTheaterDeleteCommand;

            _repository.Setup(x => x.Delete(movieTheater.Id)).Returns(true);

            //Action
            var userDeleteAction = _appService.Delete(movieTheater);

            //Assert
            userDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(movieTheater.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_MovieTheater_nao_deveria_deletar_sala_de_cinema()
        {
            //Arrange
            var movieTheater = ObjectMother.movieTheaterDeleteCommand;

            _repository.Setup(x => x.Delete(movieTheater.Id)).Returns(false);

            //Action
            var movieTheaterDeleteAction = _appService.Delete(movieTheater);

            //Assert
            movieTheaterDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(movieTheater.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_MovieTheater_deveria_atualizar_sala_de_cinema()
        {
            //Arrange
            var movieTheater = ObjectMother.movieTheaterDefault;
            var movieCmd = ObjectMother.movieTheaterUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(movieCmd.Id)).Returns(movieTheater);
            _repository.Setup(pr => pr.Update(movieTheater)).Returns(updated);

            //Action
            var movieTheaterUpdated = _appService.Update(movieCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(movieCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(movieTheater), Times.Once);
            movieTheaterUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_MovieTheater_deveria_retornar_excecao()
        {
            //Arrange
            var movieTheaterCmd = ObjectMother.movieTheaterUpdateCommand;
            _repository.Setup(x => x.GetById(movieTheaterCmd.Id)).Returns((MovieTheater)null);

            //Action
            Action act = () => _appService.Update(movieTheaterCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(movieTheaterCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<MovieTheater>()), Times.Never);
        }

        [Test]
        public void ApplService_MovieTheater_deveria_retornar_sala_de_cinema()
        {
            //Arrange
            MovieTheater movieTheater = ObjectMother.movieTheaterDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(movieTheater);

            //Action
            MovieTheater movieTheaterResult = _appService.GetById(movieTheater.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            movieTheaterResult.Should().NotBeNull();
            movieTheaterResult.Id.Should().Be(movieTheater.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_User_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<MovieTheater> movieTheaterList = ObjectMother.movieTheatersListDefault;
            _repository.Setup(x => x.GetAll()).Returns(movieTheaterList);

            //Action
            List<MovieTheater> userResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            userResultList.Should().NotBeNull();
            userResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}
