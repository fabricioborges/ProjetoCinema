using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static User userDefault
        {
            get
            {
                return new User()
                {
                    Id = 1,
                    Name = "user",
                    Email = "email@email.com"                    
                };
            }
        }

        public static IQueryable<User> userListDefault
        {
            get
            {
                List<User> users = new List<User>();

                users.Add(userDefault);
                users.Add(userDefault);
                users.Add(userDefault);

                return users.AsQueryable();
            }
        }

        public static UserAddCommand userAddCommand
        {
            get
            {
                return new UserAddCommand()
                {
                    Name = "user",
                    Email = "email@email.com",
                    Password = "123"
                };
            }
        }

        public static UserDeleteCommand userDelete
        {
            get
            {
                return new UserDeleteCommand()
                {
                    Id = 1
                };
            }
        }

        public static UserUpdateCommand userUpdateCommand
        {
            get
            {
                return new UserUpdateCommand()
                {
                    Id = 1,
                    Name = "user",
                    Email = "email@email.com",
                    Password = "password"
                };

            }
        }
    }
}
