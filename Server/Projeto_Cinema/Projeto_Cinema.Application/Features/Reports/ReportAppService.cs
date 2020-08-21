using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Cinema.Domain.Features.Reports;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;

namespace Projeto_Cinema.Application.Features.Reports
{
    public class ReportAppService : IReportAppService
    {
        IReportRepository ReportRepository;

        public ReportAppService(IReportRepository reportRepository)
        {
            ReportRepository = reportRepository;
        }
        public List<CustomerStory> GetCustomerStory(long customerId)
        {
            return ReportRepository.GetCustomerStory(customerId).ToList();
        }
    }
}
