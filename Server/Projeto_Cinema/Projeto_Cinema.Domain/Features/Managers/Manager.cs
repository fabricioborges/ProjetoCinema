using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Enums;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Managers
{
    public class Manager : Entity
    {
        public Manager()
        {
            CanAccess(AccessLevelEnum.Manager);
        }

        protected override void ValidateName()
        {
            if (String.IsNullOrEmpty(Name))
                throw new ManagerException("Nome não pode ser vazio!");
        }

        protected override void ValidateNameEmail()
        {
            if (String.IsNullOrEmpty(Email))
                throw new ManagerException("E-mail não pode ser vazio!");
        }

        protected override void ValidatePassword()
        {
            if (String.IsNullOrEmpty(Password))
                throw new ManagerException("Senha não pode ser vazio!");
        }
    }
}
