using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Snacks;
using Projeto_Cinema.Application.Features.Snacks.Commands;
using Projeto_Cinema.Application.Features.Snacks.ViewModels;
using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Snacks
{
    [RoutePrefix("api/snack")]
    public class SnackController : ApiControllerBase
    {
        public ISnackAppService SnackAppService;

        public SnackController(ISnackAppService appService) : base()
        {
            SnackAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Post(SnackAddCommand snack)
        {
            var validator = snack.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SnackAppService.Add(snack));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Snack> queryOptions)
        {
            var query = default(IQueryable<Snack>);

            query = SnackAppService.GetAll();

            return HandleQueryable<Snack, SnackViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => Mapper.Map<SnackViewModel>(SnackAppService.GetById(id)));
        }

        [HttpPut]
        public IHttpActionResult Update(SnackUpdateCommand snack)
        {
            var validator = snack.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SnackAppService.Update(snack));
        }

        [HttpDelete]
        public IHttpActionResult Delete(SnackDeleteCommand snack)
        {
            var validator = snack.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SnackAppService.Delete(snack));
        }
    }
}
