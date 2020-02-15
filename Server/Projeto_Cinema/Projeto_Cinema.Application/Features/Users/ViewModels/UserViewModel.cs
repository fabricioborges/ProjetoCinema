using Projeto_Cinema.Domain.Features.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Users.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccessLevelEnum AccessLevel { get; set; }
    }
}
