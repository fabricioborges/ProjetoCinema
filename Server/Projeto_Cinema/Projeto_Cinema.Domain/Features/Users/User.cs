using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Projeto_Cinema.Domain.Extensions;

namespace Projeto_Cinema.Domain.Features.Users
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public AccessLevelEnum AccessLevel { get; private set; }

        public virtual void Validate()
        {
            ValidateName();
            ValidateNameEmail();
        }

        public void GeneratePassword(string password)
        {
            Password = password.EncryptPassword();
        }

        public void GetPassword(string password)
        {
            Password = password.DecryptPassword();           
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

        public bool ValidatePassword(string password)
        {
            password = password.EncryptPassword();

            return Password.Equals(password);
        }

       
    }
}
