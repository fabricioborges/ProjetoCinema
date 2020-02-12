using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Common.Tests.Features
{
    public static partial class ObjectMother
    {
        public static Session sessionDefault
        {
            get
            {
                return new Session
                {
                    Movie = ObjectMother.movieDefault,
                    DateInitial = DateTime.Now,
                    MovieTheater = movieTheaterDefault,
                    Hour = DateTime.Now                    
                };
            }
        }
    }
}
