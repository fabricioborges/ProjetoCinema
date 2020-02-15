using Microsoft.Owin.Security.OAuth;
using Projeto_Cinema.API.IoC;
using Projeto_Cinema.Application.Features.Users;
using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Projeto_Cinema.API
{
    internal class ProviderAccessToken : OAuthAuthorizationServerProvider
    {
        IUserAppService UserAppService;
        IUserRepository UserRepository;

        public ProviderAccessToken()
        {

        }
        
        public ProviderAccessToken(IUserAppService appService)
        {
            UserAppService = appService;
        }

        public ProviderAccessToken(IUserRepository UserRepository)
        {
            UserAppService = new UserAppService(UserRepository);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var LoginCommand = new UserLoginCommand();
            LoginCommand.Email = context.UserName;
            LoginCommand.Password = context.Password;

            bool isUsernamePasswordValid = false;


            try
            {
                var authService = SimpleInjectorContainer.container.GetInstance<IUserAppService>();
                
                isUsernamePasswordValid = authService.GetUserByEmail(LoginCommand);
               
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
            }


            if (isUsernamePasswordValid == false)
            {
                context.SetError("invalid_grant", "Usuário não encontrado ou senha incorreta.");
                return;
            }

            var identidadeUsuario = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identidadeUsuario);
        }
    }
}