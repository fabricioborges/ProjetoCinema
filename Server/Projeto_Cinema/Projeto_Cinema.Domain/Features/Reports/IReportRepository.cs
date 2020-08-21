using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Reports
{
    public interface IReportRepository
    {
        IQueryable<CustomerStory> GetCustomerStory(long customerId);
    }
}
