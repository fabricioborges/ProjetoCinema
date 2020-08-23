using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Users;
using Projeto_Cinema.Application.Features.Users.Commands;
using Projeto_Cinema.Application.Features.Users.ViewModels;
using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Users
{
    [RoutePrefix("api/user")]
    public class UserController : ApiControllerBase
    {
        public IUserAppService UserAppService;

        public UserController(IUserAppService appService) : base()
        {
            UserAppService = appService;
        }
        
        [HttpPost]
        public IHttpActionResult Post(UserAddCommand user)
        {
            var validator = user.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => UserAppService.Add(user));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<User> queryOptions)
        {

            var query = default(IQueryable<User>);

            query = UserAppService.GetAll();

            return HandleQueryable<User, UserViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => Mapper.Map<UserViewModel>(UserAppService.GetById(id)));
        }

        [HttpPut]
        public IHttpActionResult Update(UserUpdateCommand user)
        {
            var validator = user.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => UserAppService.Update(user));
        }

        [HttpDelete]
        public IHttpActionResult Delete(UserDeleteCommand user)
        {
            var validator = user.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => UserAppService.Delete(user));
        }
    }
}
