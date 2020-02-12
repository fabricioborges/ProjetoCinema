using Projeto_Cinema.Application.Features.Movies.Commands;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Movie movieDefault
        {
            get
            {
                var duration = TimeSpan.FromHours(1);
                duration += TimeSpan.FromMinutes(40);
                duration += TimeSpan.FromSeconds(30);

                return new Movie()
                {
                    Title = "title",
                    AnimationType = AnimationTypeEnum.ThreeD,
                    Description = "description",
                    Duration = duration,
                    Image = "url image",
                    TypeAudio = TypeAudioEnum.Dubbed
                };
            }
        }

        public static MovieAddCommand movieAddCommand
        {
            get
            {
                var duration = TimeSpan.FromHours(1);
                duration += TimeSpan.FromMinutes(40);
                duration += TimeSpan.FromSeconds(30);

                return new MovieAddCommand
                {
                    Title = "title",
                    AnimationType = AnimationTypeEnum.ThreeD,
                    Description = "description",
                    Duration = duration,
                    Image = "url image",
                    TypeAudio = TypeAudioEnum.Dubbed
                };
            }
        }

        public static MovieDeleteCommand movieDeleteCommand
        {
            get
            {
                return new MovieDeleteCommand
                {
                    Id = 1
                };
            }
        }

        public static MovieUpdateCommand movieUpdateCommand
        {
            get
            {
                var duration = TimeSpan.FromHours(1);
                duration += TimeSpan.FromMinutes(40);
                duration += TimeSpan.FromSeconds(30);
                return new MovieUpdateCommand
                {
                    Id = 1,
                    Title = "title",
                    AnimationType = AnimationTypeEnum.ThreeD,
                    Description = "description",
                    Duration = duration,
                    Image = "url image",
                    TypeAudio = TypeAudioEnum.Dubbed

                };

            }
        }

        public static IQueryable<Movie> movieListDefault
        {
            get
            {
                List<Movie> movies = new List<Movie>();

                movies.Add(movieDefault);
                movies.Add(movieDefault);
                movies.Add(movieDefault);

                return movies.AsQueryable();
            }
        }
    }
}
