using Projeto_Cinema.Domain.Features.Movies;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.Movies
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            ToTable("TbMovies");

            HasKey(i => i.Id);

            Property(p => p.Image).IsRequired();
            Property(p => p.Title).IsRequired();
            Property(p => p.TypeAudio).IsRequired();
            Property(p => p.Description).IsRequired();
            Property(p => p.AnimationType).IsRequired();
            Property(p => p.Duration).IsRequired();
        }
    }
}
