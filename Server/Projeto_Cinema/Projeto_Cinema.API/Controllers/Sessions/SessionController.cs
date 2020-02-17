using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Sessions;
using Projeto_Cinema.Application.Features.Sessions.Commands;
using Projeto_Cinema.Application.Features.Sessions.ViewModels;
using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Sessions
{
    [RoutePrefix("api/session")]
    public class SessionController : ApiControllerBase
    {
        public ISessionAppService SessionAppService;

        public SessionController(ISessionAppService appService) : base()
        {
            SessionAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Post(SessionAddCommand session)
        {
            var validator = session.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SessionAppService.Add(session));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Session> queryOptions)
        {
            var query = default(IQueryable<Session>);

            query = SessionAppService.GetAll();

            return HandleQueryable<Session, SessionViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => Mapper.Map<SessionViewModel>(SessionAppService.GetById(id)));
        }

        [HttpPut]
        public IHttpActionResult Update(SessionUpdateCommand session)
        {
            var validator = session.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SessionAppService.Update(session));
        }

        [HttpDelete]
        public IHttpActionResult Delete(SessionDeleteCommand session)
        {
            var validator = session.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => SessionAppService.Delete(session));
        }
    }
}
