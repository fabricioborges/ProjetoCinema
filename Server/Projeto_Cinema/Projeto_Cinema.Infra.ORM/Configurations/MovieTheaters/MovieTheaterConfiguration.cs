﻿using Projeto_Cinema.Domain.Features.MovieTheaters;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.MovieTheaters
{
    public class MovieTheaterConfiguration : EntityTypeConfiguration<MovieTheater>
    {
        public MovieTheaterConfiguration()
        {
            ToTable("TbMovieTheaters");

            Property(p => p.Name).IsRequired();
            Ignore(p => p.QuantityOfSeats);
            HasMany(p => p.Seats).WithOptional()
                .WillCascadeOnDelete();
        }
    }
}
