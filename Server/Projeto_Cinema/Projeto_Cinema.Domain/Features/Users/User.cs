using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Users
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevelEnum AccessLevel { get; private set; }

        public virtual void Validate()
        {
            ValidateName();
            ValidateNameEmail();
            ValidatePassword();
        }

        protected void CanAccess(AccessLevelEnum accessLevel)
        {
            AccessLevel = accessLevel;
        }

        protected void ValidateName()
        {
            if (String.IsNullOrEmpty(Name))
                throw new UserException("Nome não pode ser vazio!");
        }

        protected void ValidateNameEmail()
        {
            if (String.IsNullOrEmpty(Email))
                throw new UserException("E-mail não pode ser vazio!");
        }

        protected void ValidatePassword()
        {
            if (String.IsNullOrEmpty(Password))
                throw new UserException("Senha não pode ser vazio!");
        }

        public bool ValidatePassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
