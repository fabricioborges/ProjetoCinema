using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Domain.Features.Users;
using System.Linq;

namespace Projeto_Cinema.Application.Features.Users
{
    public interface IUserAppService
    {
        User Add(UserAddCommand user);

        IQueryable<User> GetAll();

        User GetById(long Id);

        bool GetUserByEmail(UserLoginCommand loginCommand);

        bool Update(UserUpdateCommand user);

        bool Delete(UserDeleteCommand user);
    }
}
