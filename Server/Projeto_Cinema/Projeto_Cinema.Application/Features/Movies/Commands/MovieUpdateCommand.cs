using Projeto_Cinema.Domain.Features.Movies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Application.Features.Movies.Commands
{
    public class MovieUpdateCommand
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }
    }
}
