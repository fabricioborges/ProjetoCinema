using Projeto_Cinema.Application.Features.Movies.ViewModels;
using Projeto_Cinema.Application.Features.MoviesTheaters.ViewModels;
using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Sessions.ViewModels
{
    public class SessionViewModel
    {
        public long Id { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime EndDate { get; private set; }
        public DateTime Hour { get; set; }
        public MovieViewModel Movie { get; set; }
        public MovieTheaterViewModel MovieTheater { get; set; }
        public TimeSpan Duration { get; private set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }
    }
}
