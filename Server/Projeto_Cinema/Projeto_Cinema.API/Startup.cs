using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData;
using Microsoft.OData.UriParser;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Projeto_Cinema.API.IoC;
using Projeto_Cinema.Application.Config;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http;

[assembly: OwinStartup(typeof(Projeto_Cinema.API.Startup))]
namespace Projeto_Cinema.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorContainer.Initialize();

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
            EnableOdata(config);
            ConfigureCors(app);
            ActiveAccessTokens(app);
            app.UseWebApi(config);

            AutoMapperConfig.Initialize();


            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.container);
        }

        private void ActiveAccessTokens(IAppBuilder app)
        {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ProviderAccessToken()
            };

            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }


        private void ConfigureCors(IAppBuilder app)
        {
            var policy = new CorsPolicy();
            policy.AllowAnyHeader = true;
            policy.AllowAnyOrigin = true;
            policy.Origins.Add("http://localhost:3000");
            policy.Origins.Add("http://localhost:3000");
            policy.Methods.Add("GET");
            policy.Methods.Add("POST");
            policy.Methods.Add("PUT");
            policy.Methods.Add("DELETE");
            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            };
            app.UseCors(corsOptions);
        }

        private static void EnableOdata(HttpConfiguration config)
        {
            // Web API Enable OData
            config.Count().Expand().Select().Filter().OrderBy().MaxTop(null);
            config.AddODataQueryFilter();
            config.EnableDependencyInjection(builder =>
            {
                /* string as enum, substitui o antigo EnableEnumPrefixFree. Converte a String que vem no FiltroOdata para o Enum correspondente*/
                builder.AddService<ODataUriResolver>(ServiceLifetime.Singleton, sp => new StringAsEnumResolver() { EnableCaseInsensitive = true });
            });
        }
    }
}