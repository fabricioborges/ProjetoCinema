using AutoMapper;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Reports;
using Projeto_Cinema.Application.Features.Reports.ViewModels;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Reports
{
    [RoutePrefix("api/report")]
    public class ReportController : ApiControllerBase
    {
        public IReportAppService ReportAppService;

        public ReportController(IReportAppService reportAppService)
        {
            ReportAppService = reportAppService;
        }
        
        [HttpGet]
        [Route("customerstories/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var result = ReportAppService.GetCustomerStory(id);
            
            return Ok(Mapper.Map<List<CustomerStoryViewModel>>(result));
        }
    }
}
