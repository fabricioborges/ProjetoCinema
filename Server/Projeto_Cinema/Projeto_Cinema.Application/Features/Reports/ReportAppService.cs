using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Cinema.Domain.Features.Reports;
using Projeto_Cinema.Domain.Features.Reports.CustomerReports;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using Projeto_Cinema.Domain.Features.Reports.MovieReports;

namespace Projeto_Cinema.Application.Features.Reports
{
    public class ReportAppService : IReportAppService
    {
        IReportRepository ReportRepository;

        public ReportAppService(IReportRepository reportRepository)
        {
            ReportRepository = reportRepository;
        }

        public List<CustomerReport> GetCustomerReport()
        {
            return ReportRepository.GetCustomerReport().ToList();
        }

        public List<CustomerStory> GetCustomerStory(long customerId)
        {
            return ReportRepository.GetCustomerStory(customerId).ToList();
        }

        public List<MovieReport> GetMovieReport()
        {
            return ReportRepository.GetMovieReport().ToList();
        }
    }
}
