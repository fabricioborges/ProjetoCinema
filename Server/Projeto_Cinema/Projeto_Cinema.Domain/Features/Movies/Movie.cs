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
    public class Movie : Identity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Duration { get; set; }
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
            var minDate = DateTime.Parse("03/01/2000 00:00:00 -5:00");

            if (Duration.Hour <= minDate.Hour)
                if (Duration.Minute <= minDate.Minute)
                    if (Duration.Second <= minDate.Second)
                        throw new MovieException("Filme não pode ter a duração vazia!");
        }
    }
}
