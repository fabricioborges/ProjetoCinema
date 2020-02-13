using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Snacks;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.Snacks
{
    [TestFixture]
    public class SnackAppServiceTests : TestBase
    {
        Mock<ISnackRepository> _repository;
        SnackAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<ISnackRepository>();
            _appService = new SnackAppService(_repository.Object);
        }

        [Test]
        public void ApplService_Snack_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var snack = ObjectMother.snackDefault;
            snack.Id = expectedId;
            var snackAddCommand = ObjectMother.snackAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Snack>())).Returns(snack);

            //Action
            var result = _appService.Add(snackAddCommand);

            //Assert
            result.Should().Be((int)snack.Id);
            _repository.Verify(x => x.Add(It.IsAny<Snack>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Snack_deveria_deletar_snack()
        {
            //Arrange
            var snack = ObjectMother.snackDeleteCommand;

            _repository.Setup(x => x.Delete(snack.Id)).Returns(true);

            //Action
            var snackDeleteAction = _appService.Delete(snack);

            //Assert
            snackDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(snack.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Snack_nao_deveria_deletar_snack()
        {
            //Arrange
            var snack = ObjectMother.snackDeleteCommand;

            _repository.Setup(x => x.Delete(snack.Id)).Returns(false);

            //Action
            var snackDeleteAction = _appService.Delete(snack);

            //Assert
            snackDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(snack.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Snack_deveria_atualizar_snack()
        {
            //Arrange
            var snack = ObjectMother.snackDefault;
            var snackCmd = ObjectMother.snackUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(snackCmd.Id)).Returns(snack);
            _repository.Setup(pr => pr.Update(snack)).Returns(updated);

            //Action
            var snackUpdated = _appService.Update(snackCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(snackCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(snack), Times.Once);
            snackUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Snack_deveria_retornar_excecao()
        {
            //Arrange
            var snackCmd = ObjectMother.snackUpdateCommand;
            _repository.Setup(x => x.GetById(snackCmd.Id)).Returns((Snack)null);

            //Action
            Action act = () => _appService.Update(snackCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(snackCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Snack>()), Times.Never);
        }

        [Test]
        public void ApplService_Snack_deveria_retornar_snack()
        {
            //Arrange
            Snack snack = ObjectMother.snackDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(snack);

            //Action
            Snack snackResult = _appService.GetById(snack.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            snackResult.Should().NotBeNull();
            snackResult.Id.Should().Be(snack.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Snack_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Snack> snackList = ObjectMother.snackListDefault.AsQueryable();
            _repository.Setup(x => x.GetAll()).Returns(snackList);

            //Action
            List<Snack> snackResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            snackResultList.Should().NotBeNull();
            snackResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}
