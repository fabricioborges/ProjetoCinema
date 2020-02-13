using Projeto_Cinema.Application.Features.Sessions.Commands;
using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Session sessionDefault
        {
            get
            {
                return new Session
                {
                    Movie = ObjectMother.movieDefault,
                    DateInitial = DateTime.Now,
                    MovieTheater = movieTheaterDefault,
                    Hour = DateTime.Now                    
                };
            }
        }


        public static SessionAddCommand sessionAddCommand
        {
            get
            {
                return new SessionAddCommand
                {
                    Movie = ObjectMother.movieDefault,
                    DateInitial = DateTime.Now,
                    MovieTheater = movieTheaterDefault,
                    Hour = DateTime.Now
                };
            }
        }

        public static SessionDeleteCommand sessionDeleteCommand
        {
            get
            {
                return new SessionDeleteCommand
                {
                    Id = 1
                };
            }
        }

        public static SessionUpdateCommand sessionUpdateCommand
        {
            get
            {
                return new SessionUpdateCommand
                {
                    Id = 1,
                    Movie = ObjectMother.movieDefault,
                    DateInitial = DateTime.Now,
                    MovieTheater = movieTheaterDefault,
                    Hour = DateTime.Now
                };
            }
        }

        public static IQueryable<Session> sessionListDefault
        {
            get
            {
                List<Session> sessions = new List<Session>();

                sessions.Add(sessionDefault);
                sessions.Add(sessionDefault);
                sessions.Add(sessionDefault);

                return sessions.AsQueryable();
            }
        }
    }
}
