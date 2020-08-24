using Projeto_Cinema.Domain.Features.Sessions;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.Sessions
{
    public class SessionConfiguration : EntityTypeConfiguration<Session>
    {
        public SessionConfiguration()
        {
            ToTable("TbSessions");

            HasKey(i => i.Id);

            Property(p => p.MovieId).HasColumnName("MovieId").IsRequired();
            HasRequired(f => f.Movie).WithMany().HasForeignKey(k => k.MovieId).WillCascadeOnDelete();

            Property(p => p.MovieTheaterId).HasColumnName("MovieTheaterId").IsRequired();
            HasRequired(f => f.MovieTheater).WithMany().HasForeignKey(k => k.MovieTheaterId).WillCascadeOnDelete();

            Property(p => p.Hour).IsRequired();
            Property(p => p.DateInitial).IsRequired();
            Property(p => p.Duration).IsRequired();
            Property(p => p.EndDate).IsRequired();
        }
    }
}
