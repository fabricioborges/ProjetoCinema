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
                return new Movie()
                {
                    Title = "title",
                    AnimationType = AnimationTypeEnum.ThreeD,
                    Description = "description",
                    Duration = DateTime.Now.AddHours(1).AddMinutes(35).AddSeconds(55),
                    Image = "url image",
                    TypeAudio = TypeAudioEnum.Dubbed
                };
            }
        }
    }
}
