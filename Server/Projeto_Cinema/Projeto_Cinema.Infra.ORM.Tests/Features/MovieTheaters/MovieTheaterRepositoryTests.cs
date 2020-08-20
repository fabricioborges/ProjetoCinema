using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Infra.ORM.Features.MovieTheaters;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.MovieTheaters
{
    [TestFixture]
    public class MovieTheaterRepositoryTests : EffortTestBase
    {
        FakeDbContext Context;
        MovieTheatersRepository _repository;
        MovieTheater _movieTheater;
        MovieTheater _movieTheaterSeed;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new MovieTheatersRepository(Context);
            _movieTheater = ObjectMother.movieTheaterDefault;

            _movieTheaterSeed = ObjectMother.movieTheaterDefault;

            Context.MovieTheaters.Add(_movieTheaterSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_MovieTheater_deveria_gravar_uma_nova_sala()
        {
            //Arrange
            MovieTheater result = _repository.Add(_movieTheater);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_MovieTheater_deveria_retornar_uma_sala()
        {
            //Arrange
            MovieTheater movieTheater = _repository.Add(_movieTheater);

            //Action
            MovieTheater result = _repository.GetById(movieTheater.Id);

            //Assert
            result.Name.Should().Be(movieTheater.Name);
            result.Id.Should().Be(movieTheater.Id);
        }



        [Test]
        public void Repository_MovieTheater_deveria_alterar_uma_nova_sala()
        {
            //Arrange
            MovieTheater newMovieTheater = _repository.Add(_movieTheater);
            newMovieTheater.Name = "Name";

            //Action
            _repository.Update(newMovieTheater);

            //Assert
            MovieTheater result = _repository.GetById(newMovieTheater.Id);
            result.Name.Should().Be(newMovieTheater.Name);
        }

        [Test]
        public void Repository_MovieTheater_deveria_deletar_uma_sala()
        {
            //Arrange
            MovieTheater newMovieTheater = _repository.Add(_movieTheater);

            //Action
            _repository.Delete(newMovieTheater.Id);

            //Assert
            MovieTheater result = _repository.GetById(newMovieTheater.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_MovieTheater_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_MovieTheater_deveria_buscar_todos_as_salas()
        {
            //Action
            var movieTheaters = _repository.GetAll().ToList();

            //Assert
            movieTheaters.Should().NotBeNull();
            movieTheaters.Should().HaveCount(Context.MovieTheaters.Count());
            movieTheaters.First().Name.Should().Be(_movieTheaterSeed.Name);

        }
    }
}
