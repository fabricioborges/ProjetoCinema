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
        public void Dominio_Deveria_validar_campos_obrigatórios_movie()
        {
            //Action
            Action validate = () => _movie.Validate();

            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Dominio_Nao_deveria_validar_um_filme_sem_duracao()
        {
            //Arrange
            _movie.Duration = TimeSpan.Zero; ;

            //Action
            Action validate = () => _movie.Validate();

            //Assert
            validate.Should().Throw<MovieException>();
        }        
    }
}
