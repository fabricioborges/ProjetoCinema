using Projeto_Cinema.Domain.Features.Reports;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using Projeto_Cinema.Infra.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Features.Reports
{
    public class ReportRepository : IReportRepository
    {
        ProjetoCinemaContext Context;

        public ReportRepository(ProjetoCinemaContext context)
        {
            Context = context;
        }

        public IQueryable<CustomerStory> GetCustomerStory(long customerId)
        {
            return from tickets in Context.Tickets
                   join movies in Context.Movies on tickets.MovieId equals movies.Id
                   join movieTheater in Context.MovieTheaters on tickets.MovieTheaterId equals movieTheater.Id
                   join sessions in Context.Sessions on tickets.SessionId equals sessions.Id
                   where tickets.UserId == customerId
                   select new CustomerStory() { TitleMovie = movies.Title, NameMovieTheater = movieTheater.Name, DateSession = sessions.DateInitial };
        }
    }
}
