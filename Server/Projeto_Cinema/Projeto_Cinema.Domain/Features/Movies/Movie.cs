using Projeto_Cinema.Domain.Features.Base;
using Projeto_Cinema.Domain.Features.Base.Exceptions;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Domain.Features.Movies
{
    public class Movie
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DebutDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }

        public void Validate()
        {
            ValidateDescription();
            ValidateDuration();
            ValidateImage();
            ValidateTitle();
        }

        private void ValidateTitle()
        {
            if (String.IsNullOrEmpty(Title))
                throw new MovieException("Filme não pode ter um título vazio!");
        }

        private void ValidateDescription()
        {
            if (String.IsNullOrEmpty(Description))
                throw new MovieException("Filme não pode ter uma descrição vazia!");
        }

        private void ValidateImage()
        {
            if (String.IsNullOrEmpty(Image))
                throw new MovieException("Filme deve conter uma imagem!");
        }

        private void ValidateDuration()
        {
            if (TimeSpan.Zero == Duration)
                throw new MovieException("Filme deve possuir uma duração!");
        }
    }
}
