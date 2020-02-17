using Projeto_Cinema.Application.Features.Movies;
using Projeto_Cinema.Application.Features.MoviesTheaters;
using Projeto_Cinema.Application.Features.Seats;
using Projeto_Cinema.Application.Features.Sessions;
using Projeto_Cinema.Application.Features.Snacks;
using Projeto_Cinema.Application.Features.Tickets;
using Projeto_Cinema.Application.Features.Users;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using Projeto_Cinema.Domain.Features.Seats;
using Projeto_Cinema.Domain.Features.Sessions;
using Projeto_Cinema.Domain.Features.Snacks;
using Projeto_Cinema.Domain.Features.Tickets;
using Projeto_Cinema.Domain.Features.Users;
using Projeto_Cinema.Infra.ORM.Context;
using Projeto_Cinema.Infra.ORM.Features.Movies;
using Projeto_Cinema.Infra.ORM.Features.MovieTheaters;
using Projeto_Cinema.Infra.ORM.Features.Seats;
using Projeto_Cinema.Infra.ORM.Features.Sessions;
using Projeto_Cinema.Infra.ORM.Features.Snacks;
using Projeto_Cinema.Infra.ORM.Features.Tickets;
using Projeto_Cinema.Infra.ORM.Features.Users;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Projeto_Cinema.API.IoC
{
    public class SimpleInjectorContainer
    {
        public static Container container { get; internal set; }

        public static void Initialize()
        {
            container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
           
            RegisterServices(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                         new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IUserAppService, UserAppService>();
            container.Register<IMovieAppService, MovieAppService>();
            container.Register<IMovieTheatersAppService, MovieTheatersAppService>();
            container.Register<ISessionAppService, SessionAppService>();
            container.Register<ISnackAppService, SnackAppService>();
            container.Register<ISeatAppService, SeatAppService>();
            container.Register<ITicketAppService, TicketAppService>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<IMovieRepository, MovieRepository>();
            container.Register<IMovieTheaterRepository, MovieTheatersRepository>();
            container.Register<ISessionRepository, SessionRepository>();
            container.Register<ISnackRepository, SnackRepository>();
            container.Register<ITicketRepository, TicketRepository>();
            container.Register<ISeatRepository, SeatRepository>();

            container.Register(() => new ProjetoCinemaContext(), Lifestyle.Scoped);
        }
    }
}