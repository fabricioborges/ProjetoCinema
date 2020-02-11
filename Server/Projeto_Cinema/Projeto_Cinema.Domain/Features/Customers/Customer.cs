using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Enums;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Customers
{
    public class Customer : Entity
    {
        public Customer()
        {
            CanAccess(AccessLevelEnum.Customer);
        }

        public Session Session { get; set; }
        public List<Snack> Snacks { get; set; }

        protected override void ValidateName()
        {
            if (String.IsNullOrEmpty(Name))
                throw new CustomerException("Nome não pode ser vazio!");
        }

        protected override void ValidateNameEmail()
        {
            if (String.IsNullOrEmpty(Email))
                throw new CustomerException("Email não pode ser vazio!");
        }

        protected override void ValidatePassword()
        {
            if (String.IsNullOrEmpty(Password))
                throw new CustomerException("Senha não pode ser vazio!");
        }
    }
}
