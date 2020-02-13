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
                    Movie = movieDefault,
                    DateInitial = DateTime.Now,
                    MovieTheater = movieTheaterDefault,
                    Hour = DateTime.Now                    
                };
            }
        }

        public static Session sessionToPersist
        {
            get
            {
                return new Session
                {
                    Movie = movieDefault,
                    MovieId = movieDefault.Id,
                    DateInitial = DateTime.Now,
                    MovieTheater = movieTheaterDefault,
                    MovieTheaterId = movieTheaterDefault.Id,
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
                    Movie = movieDefault,
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
                    Movie = movieDefault,
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
