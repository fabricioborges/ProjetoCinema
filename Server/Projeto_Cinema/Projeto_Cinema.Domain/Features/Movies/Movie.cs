using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Movies
{
    public class Movie : Identity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }
    }
}
