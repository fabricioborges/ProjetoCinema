using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users;
using Projeto_Cinema.Infra.ORM.Context;
using System.Data.Entity;
using System.Linq;

namespace Projeto_Cinema.Infra.ORM.Features.Users
{
    public class UserRepository : IUserRepository
    {
        ProjetoCinemaContext Context;

        public UserRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public User Add(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return user;
        }

        public bool Delete(long id)
        {
            var user = Context.Users.Where(c => c.Id == id).FirstOrDefault();
            if (user == null)
                throw new NotFoundException("Registro não encontrado!");
            Context.Entry(user).State = EntityState.Deleted;
            return Context.SaveChanges() > 0;
        }

        public IQueryable<User> GetAll()
        {
            return Context.Users;
        }

        public User GetById(long Id)
        {
            return Context.Users.FirstOrDefault(u => u.Id == Id);
        }

        public User GetUserByEmail(string email)
        {
            return Context.Users.FirstOrDefault(x => x.Email.Equals(email));
        }

        public bool Update(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
            return Context.SaveChanges() > 0;
        }
    }
}
