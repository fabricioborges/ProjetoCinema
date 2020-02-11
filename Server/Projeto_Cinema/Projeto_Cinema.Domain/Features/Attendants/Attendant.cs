using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Enums;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using System;

namespace Projeto_Cinema.Domain.Features.Attendants
{
    public class Attendant : Entity
    {
        public Attendant()
        {
            CanAccess(AccessLevelEnum.Attendant);
        }

        protected override void ValidateName()
        {
            if (String.IsNullOrEmpty(Name))
                throw new AttendantException("Nome não pode ser vazio!");
        }

        protected override void ValidateNameEmail()
        {
            if (String.IsNullOrEmpty(Email))
                throw new AttendantException("E-mail não pode ser vazio!");
        }

        protected override void ValidatePassword()
        {
            if (String.IsNullOrEmpty(Password))
                throw new AttendantException("Senha não pode ser vazio!");
        }
    }
}
