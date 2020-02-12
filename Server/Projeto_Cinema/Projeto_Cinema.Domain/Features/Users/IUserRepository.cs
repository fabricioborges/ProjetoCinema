using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Users
{
    public interface IUserRepository
    {
        User Add(User user);

        IQueryable<User> GetAll();

        User GetById(long Id);

        bool Update(User user);

        bool Delete(long user);
    }
}
