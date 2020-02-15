using Microsoft.AspNet.OData.Query;
using Projeto_Cinema.API.Controllers.Common;
using Projeto_Cinema.API.Filters;
using Projeto_Cinema.Application.Features.Movies;
using Projeto_Cinema.Application.Features.Movies.Commands;
using Projeto_Cinema.Application.Features.Movies.ViewModels;
using Projeto_Cinema.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Cinema.API.Controllers.Movies
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiControllerBase
    {
        IMovieAppService MovieAppService;

        public MovieController(IMovieAppService appService)
        {
            MovieAppService = appService;
        }

        [HttpPost]
        public IHttpActionResult Post(MovieAddCommand movie)
        {
            var validator = movie.Validation();
            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);
            return HandleCallback(() => MovieAppService.Add(movie));
        }

        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult Get(ODataQueryOptions<Movie> queryOptions)
        {
            var query = default(IQueryable<Movie>);

            query = MovieAppService.GetAll();

            return HandleQueryable<Movie, MovieViewModel>(query, queryOptions);
        }

        [HttpGet]
        [Route("GetMovieInExhibition")]
        public IHttpActionResult GetMovieInExhibition(ODataQueryOptions<Movie> queryOptions)
        {

            var query = default(IQueryable<Movie>);

            query = MovieAppService.GetMovieInExhibition();

            return HandleQueryable<Movie, Movie>(query, queryOptions);
        }
    }
}
