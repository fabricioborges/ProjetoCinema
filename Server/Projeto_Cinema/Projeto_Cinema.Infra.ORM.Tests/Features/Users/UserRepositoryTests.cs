using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users;
using Projeto_Cinema.Infra.ORM.Features.Users;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.Users
{
    [TestFixture]
    public class UserRepositoryTests : EffortTestBase
    {
        private FakeDbContext Context;
        private UserRepository _repository;
        private User _user;
        private User _userSeed;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new UserRepository(Context);
            _user = ObjectMother.userDefault;

            _userSeed = ObjectMother.userDefault;

            Context.Users.Add(_userSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_User_deveria_gravar_um_novo_usuario()
        {
            //Arrange
            User result = _repository.Add(_user);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_User_deveria_retornar_um_usuario()
        {
            //Arrange
            User user = _repository.Add(_user);

            //Action
            User result = _repository.GetById(user.Id);

            //Assert
            result.Name.Should().Be(user.Name);
            result.Id.Should().Be(user.Id);
        }



        [Test]
        public void Repository_User_deveria_alterar_um_novo_usuario()
        {
            //Arrange
            User newUser = _repository.Add(_user);
            newUser.Name = "Name";

            //Action
            _repository.Update(newUser);

            //Assert
            User result = _repository.GetById(newUser.Id);
            result.Name.Should().Be(newUser.Name);
        }

        [Test]
        public void Repository_User_deveria_deletar_um_usuario()
        {
            //Arrange
            User newUser = _repository.Add(_user);

            //Action
            _repository.Delete(newUser.Id);

            //Assert
            User result = _repository.GetById(newUser.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_User_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_User_deveria_buscar_todos_os_Users()
        {
            //Action
            var users = _repository.GetAll().ToList();

            //Assert
            users.Should().NotBeNull();
            users.Should().HaveCount(Context.Users.Count());
            users.First().Should().Be(_userSeed);

        }
    }
}
