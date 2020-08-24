using Projeto_Cinema.Domain.Features.Movies;
using Projeto_Cinema.Domain.Features.Movies.Enums;
using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;

namespace Projeto_Cinema.Domain.Features.Sessions
{
    public class Session 
    {
        public long Id { get; set; }
        public DateTime DateInitial { get; set; }
        public DateTime EndDate { get; private set; }
        public DateTime Hour { get; set; }
        public virtual Movie Movie { get; set; }
        public long MovieId { get; set; }
        public virtual MovieTheater MovieTheater { get; set; }
        public long MovieTheaterId { get; set; }
        public TimeSpan Duration { get; private set; }
        public AnimationTypeEnum AnimationType { get; set; }
        public TypeAudioEnum TypeAudio { get; set; }
        public double ValueOfSeats { get; set; }

        public bool CanRemove()
        {
            var targetDate = DateTime.Now - DateInitial;
            return targetDate.Days >= 10;
        }

        public void setHour()
        {
            var day = DateInitial.Day - 1;

            var month = DateInitial.Month - 1;

            var year = DateInitial.Year - 1;

            var hour = Hour.Hour;

            var minute = Hour.Minute;

            Hour = new DateTime()
                .AddDays(day).AddMonths(month).AddYears(year).AddHours(hour).AddMinutes(minute);
        }
        public void SetDuration() => Duration = Movie.Duration;       

        public void SetEndDate() => EndDate = Movie.EndDate;
    }
}
