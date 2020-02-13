using Effort;
using FluentAssertions;
using NUnit.Framework;
using Projeto_Cinema.Common.Tests.Features;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Infra.ORM.Features.Snacks;
using Projeto_Cinema.Infra.ORM.Tests.Context;
using Projeto_Cinema.Infra.ORM.Tests.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Tests.Features.Snacks
{
    [TestFixture]
    public class SnackRepositoryTests : EffortTestBase
    {
        FakeDbContext Context;
        SnackRepository _repository;
        Snack _snack;
        Snack _snackSeed;

        [SetUp]
        public void SetUp()
        {
            var connection = DbConnectionFactory.CreatePersistent(Guid.NewGuid().ToString());
            Context = new FakeDbContext(connection);
            _repository = new SnackRepository(Context);
            _snack = ObjectMother.snackDefault;

            _snackSeed = ObjectMother.snackDefault;

            Context.Snacks.Add(_snackSeed);
            Context.SaveChanges();
        }

        [Test]
        public void Repository_Snack_deveria_gravar_um_novo_snack()
        {
            //Arrange
            Snack result = _repository.Add(_snack);

            result.Id.Should().BeGreaterThan(0);
        }

        [Test]
        public void Repository_Snack_deveria_retornar_um_snack()
        {
            //Arrange
            Snack snack = _repository.Add(_snack);

            //Action
            Snack result = _repository.GetById(snack.Id);

            //Assert
            result.Name.Should().Be(snack.Name);
            result.Id.Should().Be(snack.Id);
        }



        [Test]
        public void Repository_Snack_deveria_alterar_um_novo_snack()
        {
            //Arrange
            Snack newSnack = _repository.Add(_snack);
            newSnack.Name = "Name";

            //Action
            _repository.Update(newSnack);

            //Assert
            Snack result = _repository.GetById(newSnack.Id);
            result.Name.Should().Be(newSnack.Name);
        }

        [Test]
        public void Repository_Snack_deveria_deletar_um_snack()
        {
            //Arrange
            Snack newSnack = _repository.Add(_snack);

            //Action
            _repository.Delete(newSnack.Id);

            //Assert
            Snack result = _repository.GetById(newSnack.Id);
            result.Should().BeNull();
        }

        [Test]
        public void Repository_Snack_deveria_lancar_notFoundException()
        {
            //Action
            Action removing = () => _repository.Delete(0);

            // Assert
            removing.Should().Throw<NotFoundException>();
        }


        [Test]
        public void Repository_Snack_deveria_buscar_todos_os_Snacks()
        {
            //Action
            var snacks = _repository.GetAll().ToList();

            //Assert
            snacks.Should().NotBeNull();
            snacks.Should().HaveCount(Context.Snacks.Count());
            snacks.First().Should().Be(_snackSeed);

        }
    }
}
