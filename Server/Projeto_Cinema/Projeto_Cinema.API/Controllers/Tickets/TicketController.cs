using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Tickets;
using Projeto_Cinema.Application.Features.Tickets.Commands;
using Projeto_Cinema.Application.Features.Tickets.ViewModels;
using Projeto_Cinema.Domain.Features.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Tickets
{
    [RoutePrefix("api/ticket")]
    public class TicketController : ApiControllerBase
    {
        public ITicketAppService TicketAppService;

        public TicketController(ITicketAppService appService) : base()
        {
            TicketAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Post(TicketAddCommand user)
        {
            var validator = user.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => TicketAppService.Add(user));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Ticket> queryOptions)
        {
            var query = default(IQueryable<Ticket>);

            query = TicketAppService.GetAll();

            return HandleQueryable<Ticket, TicketViewModel>(query, queryOptions);
        }
                       

    }
}
