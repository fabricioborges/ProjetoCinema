using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Domain.Features.Users;
using System.Linq;

namespace Projeto_Cinema.Application.Features.Users
{
    public interface IUserAppService
    {
        long Add(UserAddCommand user);

        IQueryable<User> GetAll();

        User GetById(long Id);

        bool Update(UserUpdateCommand user);

        bool Delete(UserDeleteCommand user);
    }
}
