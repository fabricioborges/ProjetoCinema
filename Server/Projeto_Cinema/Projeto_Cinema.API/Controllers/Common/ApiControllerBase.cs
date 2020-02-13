using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Exceptions;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Common
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            try
            {
                return Ok(func());
            }
            catch (Exception e)
            {
                return HandleFailure(e);
            }
        }
        protected IHttpActionResult HandleQuery<TSource, TResult>(TSource result)
        {
            return Ok(Mapper.Map<TSource, TResult>(result));
        }

        protected IHttpActionResult HandleQueryable<TSource, TResult>(IQueryable<TSource> query, ODataQueryOptions<TSource> queryOptions)
        {
            var odataQuery = queryOptions.ApplyTo(query).Cast<TSource>();
            var dataQuery = odataQuery.ToList().AsQueryable().ProjectTo<TResult>();
            var pageResult = new PageResult<TResult>(dataQuery,
                                    Request.ODataProperties().NextLink,
                                    Request.ODataProperties().TotalCount);
            // Esse .ToList() é performado no ProjectTo e não mais no EF
            return Ok(pageResult);
        }

        protected IHttpActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            var exceptionPayload = ExceptionPayload.New(exceptionToHandle);
            return exceptionToHandle is BusinessException ?
                Content(HttpStatusCode.BadRequest, exceptionPayload) :
                Content(HttpStatusCode.InternalServerError, exceptionPayload);
        }

        protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure)
           where T : ValidationFailure
        {
            return Content(HttpStatusCode.BadRequest, validationFailure);
        }
    }
}
