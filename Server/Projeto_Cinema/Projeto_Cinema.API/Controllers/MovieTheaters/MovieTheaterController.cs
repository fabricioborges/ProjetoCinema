using AutoMapper;
using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.MoviesTheaters;
using Projeto_Cinema.Application.Features.MoviesTheaters.Commands;
using Projeto_Cinema.Application.Features.MoviesTheaters.ViewModels;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.MovieTheaters
{
    [RoutePrefix("api/movieTheater")]
    public class MovieTheaterController : ApiControllerBase
    {
        public IMovieTheatersAppService MovieTheaterAppService;

        public MovieTheaterController(IMovieTheatersAppService appService) : base()
        {
            MovieTheaterAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Post(MovieTheaterAddCommand movieTheater)
        {
            var validator = movieTheater.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => MovieTheaterAppService.Add(movieTheater));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<MovieTheater> queryOptions)
        {
            var query = default(IQueryable<MovieTheater>);

            query = MovieTheaterAppService.GetAll();

            return HandleQueryable<MovieTheater, MovieTheaterViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => Mapper.Map<MovieTheaterViewModel>(MovieTheaterAppService.GetById(id)));
        }

        [HttpPut]
        public IHttpActionResult Update(MovieTheaterUpdateCommand movieTheater)
        {
            var validator = movieTheater.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => MovieTheaterAppService.Update(movieTheater));
        }

        [HttpDelete]
        public IHttpActionResult Delete(MovieTheaterDeleteCommand movieTheater)
        {
            var validator = movieTheater.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => MovieTheaterAppService.Delete(movieTheater));
        }
    }
}
