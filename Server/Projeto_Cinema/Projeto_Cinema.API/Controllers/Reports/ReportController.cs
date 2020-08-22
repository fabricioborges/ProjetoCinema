using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Reports;
using Projeto_Cinema.Application.Features.Reports.ViewModels;
using Projeto_Cinema.Domain.Features.Reports.CustomerStories;
using Projeto_Cinema.Domain.Features.Reports.MovieReports;
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
        public IHttpActionResult GetCustomerStory(int id)
        {
            var result = ReportAppService.GetCustomerStory(id);

            return Ok(Mapper.Map<List<CustomerStoryViewModel>>(result));
        }

        [HttpGet]
        [Route("moviereport")]
        public IHttpActionResult GetMovieReport()
        {
            var result = ReportAppService.GetMovieReport();

            return Ok(Mapper.Map<List<MovieReportViewModel>>(result));
        }

        [HttpGet]
        [Route("customerreport")]
        public IHttpActionResult GetCustomerReport()
        {
            var result = ReportAppService.GetCustomerReport();

            return Ok(Mapper.Map<List<CustomerReportViewModel>>(result));
        }
    }
}
