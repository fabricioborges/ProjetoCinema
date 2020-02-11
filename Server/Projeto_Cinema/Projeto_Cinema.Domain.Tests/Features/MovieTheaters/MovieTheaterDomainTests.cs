using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Tests.Features.MovieTheaters
{
    [TestFixture]
    public class MovieTheaterDomainTests
    {
        MovieTheater _movieTheater;

        [SetUp]
        public void SetUp()
        {
            _movieTheater = ObjectMother.movieTheaterDefault;
        }

        [Test]
        public void Nao_deveria_permitir_sala_com_menos_de_20_assentos()
        {
            //Arrange
            ObjectMother.CreateListOfSeats(19);
           
            //Action
            Action validate = () => _movieTheater.ValidateNumberOfSeats();

            //Assert
            validate.Should().Throw<MovieTheaterException>();
        }

        [Test]
        public void Nao_deveria_permitir_sala_com_mais_de_100_assentos()
        {
            //Arrange
            ObjectMother.CreateListOfSeats(200);

            //Action
            Action validate = () => _movieTheater.ValidateNumberOfSeats();

            //Assert
            validate.Should().Throw<MovieTheaterException>();

            
        }
    }
}
