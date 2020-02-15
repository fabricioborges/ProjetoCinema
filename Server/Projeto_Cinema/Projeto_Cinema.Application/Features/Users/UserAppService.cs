using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users;

namespace Projeto_Cinema.Application.Features.Users
{
    public class UserAppService : IUserAppService
    {
        IUserRepository UserRepository;

        public UserAppService(IUserRepository repository)
        {
            UserRepository = repository;
        }

        public long Add(UserAddCommand user)
        {
            var userAdd = Mapper.Map<UserAddCommand, User>(user);
            userAdd.GeneratePassword(userAdd.Password);
            var newUser = UserRepository.Add(userAdd);

            return newUser.Id;
        }

        public bool Delete(UserDeleteCommand user)
        {
            return UserRepository.Delete(user.Id);                       
        }

        public IQueryable<User> GetAll()
        {
            return UserRepository.GetAll();
        }

        public User GetById(long Id)
        {
            return UserRepository.GetById(Id);
        }

        public bool GetUserByEmail(UserLoginCommand loginCommand)
        {
            var user = UserRepository.GetUserByEmail(loginCommand.Email);

            if (user != null)
            {
                return user.ValidatePassword(loginCommand.Password);
            }
            else
                return false;

        }

        public bool Update(UserUpdateCommand user)
        {
            var userDb = UserRepository.GetById(user.Id);
            if (userDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var userEdit = Mapper.Map(user, userDb);

            return UserRepository.Update(userEdit);
        }
    }
}
