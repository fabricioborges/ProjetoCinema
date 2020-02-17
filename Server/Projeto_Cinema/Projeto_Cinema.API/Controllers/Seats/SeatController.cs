using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Seats;
using Projeto_Cinema.Application.Features.Seats.Commands;
using Projeto_Cinema.Application.Features.Seats.ViewModels;
using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Seats
{
    [RoutePrefix("api/seat")]
    public class SeatController : ApiControllerBase
    {
        public ISeatAppService SeatAppService;

        public SeatController(ISeatAppService appService) : base()
        {
            SeatAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Post(SeatAddCommand seat)
        {
            var validator = seat.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SeatAppService.Add(seat));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Seat> queryOptions)
        {
            var query = default(IQueryable<Seat>);

            query = SeatAppService.GetAll();

            return HandleQueryable<Seat, SeatViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => Mapper.Map<SeatViewModel>(SeatAppService.GetById(id)));
        }

        [HttpPut]
        public IHttpActionResult Update(SeatUpdateCommand seat)
        {
            var validator = seat.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SeatAppService.Update(seat));
        }

        [HttpDelete]
        public IHttpActionResult Delete(SeatDeleteCommand seat)
        {
            var validator = seat.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SeatAppService.Delete(seat));
        }
    }
}
