using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Tests.Features.Users
{
    class UserDomainTests
    {
        User _user;

        [SetUp]
        public void SetUp()
        {
            _user = ObjectMother.userDefault;
        }

        [Test]
        public void Dominio_Deveria_validar_campos_obrigatorios_do_customer()
        {
            //Action
            Action validate = () => _user.Validate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Dominio_Deveria_retornar_excessao_nome_nulo()
        {
            //Arrange
            _user.Name = string.Empty;

            //Action
            Action validate = () => _user.Validate();

            //Assert
            validate.Should().Throw<UserException>();
        }

        [Test]
        public void Dominio_Deveria_retornar_excessao_email_nulo()
        {
            //Arrange
            _user.Email = string.Empty;

            //Action
            Action validate = () => _user.Validate();

            //Assert
            validate.Should().Throw<UserException>();
        }

        [Test]
        public void Dominio_Deveria_retornar_a_senha_sem_criptografia()
        {
            //Arrange
            var password = "123456";
            _user.GeneratePassword(password);

            //Action
           _user.GetPassword(_user.Password);

            //Assert
            _user.Password.Should().Be(password);
        }
        
    }
}
