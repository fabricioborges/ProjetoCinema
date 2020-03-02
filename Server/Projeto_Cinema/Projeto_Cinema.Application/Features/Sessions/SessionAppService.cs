using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Cinema.Application.Features.Sessions.Commands;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Sessions;

namespace Projeto_Cinema.Application.Features.Sessions
{
    public class SessionAppService : ISessionAppService
    {
        ISessionRepository SessionRepository;
        IMovieRepository MovieRepository;

        public SessionAppService(ISessionRepository repository, IMovieRepository movieRepository)
        {
            SessionRepository = repository;
            MovieRepository = movieRepository;
        }

        public long Add(SessionAddCommand session)
        {
            var sessionAdd = Mapper.Map<SessionAddCommand, Session>(session);

            var movie = MovieRepository.GetById(session.MovieId);

            sessionAdd.Movie = movie;

            sessionAdd.SetDuration();

            sessionAdd.SetEndDate();

            var newSession = SessionRepository.Add(sessionAdd);

            return newSession.Id;
        }

        public bool Delete(SessionDeleteCommand session)
        {
            return SessionRepository.Delete(session.Id);
        }

        public IQueryable<Session> GetAll()
        {
            return SessionRepository.GetAll();
        }

        public Session GetById(long Id)
        {
            return SessionRepository.GetById(Id);
        }

        public bool Update(SessionUpdateCommand session)
        {
            var sessionDb = SessionRepository.GetById(session.Id);
            if (sessionDb == null)
                throw new NotFoundException("Registro não encontrado!");

            var seatEdit = Mapper.Map(session, sessionDb);
            var movie = MovieRepository.GetById(session.MovieId);

            seatEdit.Movie = movie;

            seatEdit.SetDuration();

            seatEdit.SetEndDate();

            return SessionRepository.Update(seatEdit);
        }
    }
}
