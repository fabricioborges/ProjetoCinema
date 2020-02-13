using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Infra.ORM.Features.Sessions;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.Sessions
{
    [TestFixture]
    public class SessionRepositoryTests : EffortTestBase
    {
        FakeDbContext Context;
        SessionRepository _repository;
        Session _session;
        Session _sessionSeed;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new SessionRepository(Context);
            _session = ObjectMother.sessionToPersist;

            _sessionSeed = ObjectMother.sessionToPersist;

            Context.Sessions.Add(_sessionSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_Session_deveria_gravar_um_novo_sessao()
        {
            //Arrange
            Session result = _repository.Add(_session);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Session_deveria_retornar_um_sessao()
        {
            //Arrange
            Session session = _repository.Add(_session);

            //Action
            Session result = _repository.GetById(session.Id);

            //Assert
            result.MovieId.Should().Be(session.MovieId);
            result.Id.Should().Be(session.Id);
        }



        [Test]
        public void Repository_Session_deveria_alterar_um_novo_sessao()
        {
            //Arrange
            Session newSession = _repository.Add(_session);
            newSession.Hour = DateTime.Now;

            //Action
            _repository.Update(newSession);

            //Assert
            Session result = _repository.GetById(newSession.Id);
            result.Hour.Should().Be(newSession.Hour);
        }

        [Test]
        public void Repository_Session_deveria_deletar_um_sessao()
        {
            //Arrange
            Session newSession = _repository.Add(_session);

            //Action
            _repository.Delete(newSession.Id);

            //Assert
            Session result = _repository.GetById(newSession.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_Session_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_Session_deveria_buscar_todos_as_sessoes()
        {
            //Action
            var sessions = _repository.GetAll().ToList();

            //Assert
            sessions.Should().NotBeNull();
            sessions.Should().HaveCount(Context.Sessions.Count());
            sessions.First().Should().Be(_sessionSeed);

        }
    }
}
