using Projeto_Cinema.Domain.Features.Base.Enums;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Base
{
    public abstract class Entity : Identity
    {
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

        protected abstract void ValidatePassword();
       

        protected abstract void ValidateNameEmail();
        

        protected abstract void ValidateName();
    }
}
