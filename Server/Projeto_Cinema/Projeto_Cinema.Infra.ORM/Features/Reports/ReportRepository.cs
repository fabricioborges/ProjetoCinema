using Projeto_Cinema.Domain.Features.Reports;
using Projeto_Cinema.Domain.Features.Reports.CustomerReports;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using Projeto_Cinema.Domain.Features.Reports.MovieReports;
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

        public IQueryable<CustomerReport> GetCustomerReport()
        {
            var result = from customer in Context.Users
                         join tickets in Context.Tickets on customer.Id equals tickets.UserId
                         select new { customer.Name, customer.Email, tickets.Value };

            return result.GroupBy(x => new { x.Name, x.Email })
                .Select(x => new CustomerReport { Name = x.Key.Name, Email = x.Key.Email, Value = x.Sum(y => y.Value)})
                .OrderByDescending(x => x.Value);
                
        }

        public IQueryable<CustomerStory> GetCustomerStory(long customerId)
        {
            return from tickets in Context.Tickets
                   join movies in Context.Movies on tickets.MovieId equals movies.Id
                   join movieTheater in Context.MovieTheaters on tickets.MovieTheaterId equals movieTheater.Id
                   join sessions in Context.Sessions on tickets.SessionId equals sessions.Id
                   where tickets.UserId == customerId
                   select new CustomerStory { TitleMovie = movies.Title, NameMovieTheater = movieTheater.Name, DateSession = sessions.DateInitial };
        }

        public IQueryable<MovieReport> GetMovieReport()
        {
            var result = from movies in Context.Movies
                   join tickes in Context.Tickets on movies.Id equals tickes.MovieId
                   select new { TitleMovie = movies.Title, Value = tickes.Value };

            return result.GroupBy(x => x.TitleMovie)
                .Select(x => new MovieReport { TitleMovie = x.Key, Value = x.Sum(y => y.Value) })
                .OrderByDescending(x => x.Value);
        }
    }
}
