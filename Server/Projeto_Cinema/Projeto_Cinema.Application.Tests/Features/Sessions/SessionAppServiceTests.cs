using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_Cinema.Application.Features.Sessions;
using Projeto_Cinema.Application.Tests.Initializer;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Tests.Features.Sessions
{
    [TestFixture]
    public class SessionAppServiceTests : TestBase
    {
        Mock<ISessionRepository> _repository;
        Mock<IMovieRepository> _movieRepository;
        SessionAppService _appService;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<ISessionRepository>();
            _movieRepository = new Mock<IMovieRepository>();
            _appService = new SessionAppService(_repository.Object, _movieRepository.Object);
        }

        [Test]
        public void ApplService_Session_deveria_adicionar()
        {
            //Arrange
            long expectedId = 1;
            var session = ObjectMother.sessionDefault;
            session.Id = expectedId;
            var sesionAddCommand = ObjectMother.sessionAddCommand;
            _repository.Setup(x => x.Add(It.IsAny<Session>())).Returns(session);
            _movieRepository.Setup(x => x.GetById(It.IsAny<long>())).Returns(It.IsAny<Movie>());

            //Action
            var result = _appService.Add(sesionAddCommand);

            //Assert
            result.Should().Be((int)session.Id);
            _repository.Verify(x => x.Add(It.IsAny<Session>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Session_deveria_deletar_sessao()
        {
            //Arrange
            var session = ObjectMother.sessionDeleteCommand;

            _repository.Setup(x => x.Delete(session.Id)).Returns(true);

            //Action
            var sessionDeleteAction = _appService.Delete(session);

            //Assert
            sessionDeleteAction.Should().BeTrue();
            _repository.Verify(x => x.Delete(session.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Session_nao_deveria_deletar_sessao()
        {
            //Arrange
            var session = ObjectMother.sessionDeleteCommand;

            _repository.Setup(x => x.Delete(session.Id)).Returns(false);

            //Action
            var sessionDeleteAction = _appService.Delete(session);

            //Assert
            sessionDeleteAction.Should().BeFalse();
            _repository.Verify(x => x.Delete(session.Id), Times.Once());
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Session_deveria_atualizar_sessao()
        {
            //Arrange
            var session = ObjectMother.sessionDefault;
            var sesionCmd = ObjectMother.sessionUpdateCommand;
            var updated = true;
            _repository.Setup(x => x.GetById(sesionCmd.Id)).Returns(session);
            _repository.Setup(pr => pr.Update(session)).Returns(updated);

            //Action
            var sessionUpdated = _appService.Update(sesionCmd);

            //Assert
            _repository.Verify(pr => pr.GetById(sesionCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(session), Times.Once);
            sessionUpdated.Should().BeTrue();
        }

        [Test]
        public void ApplService_Session_deveria_retornar_excecao()
        {
            //Arrange
            var sessionCmd = ObjectMother.sessionUpdateCommand;
            _repository.Setup(x => x.GetById(sessionCmd.Id)).Returns((Session)null);

            //Action
            Action act = () => _appService.Update(sessionCmd);

            //Assert
            act.Should().Throw<NotFoundException>();
            _repository.Verify(pr => pr.GetById(sessionCmd.Id), Times.Once);
            _repository.Verify(pr => pr.Update(It.IsAny<Session>()), Times.Never);
        }

        [Test]
        public void ApplService_Session_deveria_retornar_filme()
        {
            //Arrange
            Session session = ObjectMother.sessionDefault;
            _repository.Setup(x => x.GetById(It.IsAny<long>())).Returns(session);

            //Action
            Session sessionResult = _appService.GetById(session.Id);

            //Assert
            _repository.Verify(p => p.GetById(It.IsAny<long>()), Times.Once());
            sessionResult.Should().NotBeNull();
            sessionResult.Id.Should().Be(session.Id);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void ApplService_Session_GetAll_Deve_Chamar_OMetodo_GetAll()
        {
            //Arrange
            IQueryable<Session> sessionList = ObjectMother.sessionListDefault;
            _repository.Setup(x => x.GetAll()).Returns(sessionList);

            //Action
            List<Session> sessionResultList = _appService.GetAll().ToList();

            //Assert
            _repository.Verify(x => x.GetAll());
            sessionResultList.Should().NotBeNull();
            sessionResultList.Should().HaveCount(3);
            _repository.VerifyNoOtherCalls();
        }
    }
}
