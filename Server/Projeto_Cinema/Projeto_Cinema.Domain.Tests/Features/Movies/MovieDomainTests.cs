using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Tests.Features.Movies
{
    [TestFixture]
    public class MovieDomainTests
    {
        Movie _movie;

        [SetUp]
        public void SetUp()
        {
            _movie = ObjectMother.movieDefault;
        }

        [Test]
        public void Deveria_validar_campos_obrigatórios_movie()
        {
            //Action
            Action validate = () => _movie.Validate();

            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Deveria_validar_um_filme_com_duracao_de_minutos()
        {
            //Arrange
            _movie.Duration = DateTime.Parse("03/01/2009 00:45:00 -5:00");

            //Action
            Action validate = () => _movie.Validate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Deveria_validar_um_filme_com_duracao_de_segundos()
        {
            //Arrange
            _movie.Duration = DateTime.Parse("03/01/2009 00:00:15 -5:00");

            //Action
            Action validate = () => _movie.Validate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Nao_deveria_validar_um_filme_com_duracao_de_zerada()
        {
            //Arrange
            _movie.Duration = DateTime.Parse("03/01/2009 00:00:00 -5:00");

            //Action
            Action validate = () => _movie.Validate();

            //Assert
            validate.Should().Throw<MovieException>();
        }
    }
}
