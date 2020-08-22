using Projeto_Cinema.Domain.Features.Reports.CustomerReports;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using Projeto_Cinema.Domain.Features.Reports.MovieReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Reports
{
    public interface IReportAppService
    {
        List<CustomerStory> GetCustomerStory(long customerId);

        List<MovieReport> GetMovieReport();

        List<CustomerReport> GetCustomerReport();
    }
}
