using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Infra.ORM.Features.Movies;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.Movies
{
    [TestFixture]
    public class MovieRepositoryTests : EffortTestBase
    {
        FakeDbContext Context;
        MovieRepository _repository;
        Movie _movie;
        Movie _movieSeed;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new MovieRepository(Context);
            _movie = ObjectMother.movieDefault;

            _movieSeed = ObjectMother.movieDefault;

            Context.Movies.Add(_movieSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_Movie_deveria_gravar_um_novo_filme()
        {
            //Arrange
            Movie result = _repository.Add(_movie);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Movie_deveria_retornar_um_filme()
        {
            //Arrange
            Movie movie = _repository.Add(_movie);

            //Action
            Movie result = _repository.GetById(movie.Id);

            //Assert
            result.Title.Should().Be(movie.Title);
            result.Id.Should().Be(movie.Id);
        }



        [Test]
        public void Repository_Movie_deveria_alterar_um_novo_filme()
        {
            //Arrange
            Movie newMovie = _repository.Add(_movie);
            newMovie.Title = "Name";

            //Action
            _repository.Update(newMovie);

            //Assert
            Movie result = _repository.GetById(newMovie.Id);
            result.Title.Should().Be(newMovie.Title);
        }

        [Test]
        public void Repository_Movie_deveria_deletar_um_filme()
        {
            //Arrange
            Movie newMovie = _repository.Add(_movie);

            //Action
            _repository.Delete(newMovie.Id);

            //Assert
            Movie result = _repository.GetById(newMovie.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_Movie_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_Movie_deveria_buscar_todos_os_filmes()
        {
            //Action
            var movies = _repository.GetAll().ToList();

            //Assert
            movies.Should().NotBeNull();
            movies.Should().HaveCount(Context.Movies.Count());
            movies.First().Should().Be(_movieSeed);

        }
    }
}
