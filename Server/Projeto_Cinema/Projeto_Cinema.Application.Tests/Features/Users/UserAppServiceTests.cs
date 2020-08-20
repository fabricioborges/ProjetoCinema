using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Users;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.Users
{
    [TestFixture]
    public class UserAppServiceTests : TestBase
    {
        Mock<IUserRepository> _repository;
        UserAppService _appService;
        
        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IUserRepository>();
            _appService = new UserAppService(_repository.Object);
        }

        [Test]
        public void ApplService_User_deveria_adicionar()
        { 
            //Arrange
            long expectedId = 1;
            var user = ObjectMother.userDefault;
            user.Id = expectedId;
            var userAddCommand = ObjectMother.userAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<User>())).Returns(user);

            //Action
            var result = _appService.Add(userAddCommand);

            //Assert
            result.Should().Be((int)user.Id);
            _repository.Verify(x => x.Add(It.IsAny<User>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_User_deveria_deletar_usuario()
        {
            //Arrange
            var user = ObjectMother.userDelete;

            _repository.Setup(x => x.Delete(user.Id)).Returns(true);

            //Action
            var userDeleteAction = _appService.Delete(user);

            //Assert
            userDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(user.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_User_nao_deveria_deletar_usuario()
        {
            //Arrange
            var user = ObjectMother.userDelete;

            _repository.Setup(x => x.Delete(user.Id)).Returns(false);

            //Action
            var userDeleteAction = _appService.Delete(user);

            //Assert
            userDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(user.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_user_deveria_atualizar_usuario()
        {
            //Arrange
            var user = ObjectMother.userDefault;
            var userCmd = ObjectMother.userUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(userCmd.Id)).Returns(user);
            _repository.Setup(pr => pr.Update(user)).Returns(updated);
            
            //Action
            var userUpdated = _appService.Update(userCmd);
            
            //Assert
            _repository.Verify(pr => pr.GetById(userCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(user), Times.Once);
            userUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_user_deveria_retornar_excecao()
        {
            //Arrange
            var userCmd = ObjectMother.userUpdateCommand;
            _repository.Setup(x => x.GetById(userCmd.Id)).Returns((User)null);

            //Action
            Action act = () => _appService.Update(userCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(userCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<User>()), Times.Never);
        }

        [Test]
        public void ApplService_user_deveria_retornar_usuario()
        {
            //Arrange
            User user = ObjectMother.userDefault;
            user.GeneratePassword("123");
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(user);

            //Action
            User userResult = _appService.GetById(user.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            userResult.Should().NotBeNull();
            userResult.Id.Should().Be(user.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_User_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<User> userList = ObjectMother.userListDefault;
            _repository.Setup(x => x.GetAll()).Returns(userList);

            //Action
            List<User> userResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            userResultList.Should().NotBeNull();
            userResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }

    }
}
