using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Movies;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.Movies
{
    [TestFixture]
    public class MovieAppServiceTests : TestBase
    {
        Mock<IMovieRepository> _repository;
        MovieAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IMovieRepository>();
            _appService = new MovieAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Movie_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var movie = ObjectMother.movieDefault;
            movie.Id = expectedId;
            var movieAddCommand = ObjectMother.movieAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Movie>())).Returns(movie);

            //Action
            var result = _appService.Add(movieAddCommand);

            //Assert
            result.Should().Be((int)movie.Id);
            _repository.Verify(x => x.Add(It.IsAny<Movie>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Movie_deveria_deletar_filme()
        {
            //Arrange
            var movie = ObjectMother.movieDeleteCommand;

            _repository.Setup(x => x.Delete(movie.Id)).Returns(true);

            //Action
            var movieDeleteAction = _appService.Delete(movie);

            //Assert
            movieDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(movie.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Movie_nao_deveria_deletar_filme()
        {
            //Arrange
            var movie = ObjectMother.movieDeleteCommand;

            _repository.Setup(x => x.Delete(movie.Id)).Returns(false);

            //Action
            var movieDeleteAction = _appService.Delete(movie);

            //Assert
            movieDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(movie.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Movie_deveria_atualizar_filme()
        {
            //Arrange
            var movie = ObjectMother.movieDefault;
            var movieCmd = ObjectMother.movieUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(movieCmd.Id)).Returns(movie);
            _repository.Setup(pr => pr.Update(movie)).Returns(updated);

            //Action
            var movieUpdated = _appService.Update(movieCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(movieCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(movie), Times.Once);
            movieUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Movie_deveria_retornar_excecao()
        {
            //Arrange
            var movieCmd = ObjectMother.movieUpdateCommand;
            _repository.Setup(x => x.GetById(movieCmd.Id)).Returns((Movie)null);

            //Action
            Action act = () => _appService.Update(movieCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(movieCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Movie>()), Times.Never);
        }

        [Test]
        public void ApplService_Movie_deveria_retornar_filme()
        {
            //Arrange
            Movie movie = ObjectMother.movieDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(movie);

            //Action
            Movie movieResult = _appService.GetById(movie.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            movieResult.Should().NotBeNull();
            movieResult.Id.Should().Be(movie.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Movie_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Movie> movieList = ObjectMother.movieListDefault;
            _repository.Setup(x => x.GetAll()).Returns(movieList);

            //Action
            List<Movie> movieResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            movieResultList.Should().NotBeNull();
            movieResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}
