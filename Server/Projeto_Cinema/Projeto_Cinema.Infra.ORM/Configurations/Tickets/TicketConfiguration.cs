using Projeto_Cinema.Domain.Features.Tickets;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.Tickets
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            ToTable("TbTickets");

            HasKey(i => i.Id);

            Property(p => p.Value).IsRequired();

            Property(p => p.UserId).HasColumnName("UserId").IsOptional();
            HasOptional(f => f.User).WithMany().HasForeignKey(k => k.UserId);

            Property(p => p.SessionId).HasColumnName("SessionId").IsOptional();
            HasOptional(f => f.Session).WithMany().HasForeignKey(k => k.SessionId);

            Property(p => p.MovieTheaterId).HasColumnName("MovieTheaterId").IsOptional();
            HasOptional(f => f.MovieTheater).WithMany().HasForeignKey(k => k.MovieTheaterId);

            Property(p => p.MovieId).HasColumnName("MovieId").IsOptional();
            HasOptional(f => f.Movie).WithMany().HasForeignKey(k => k.MovieId);
                        
            Property(p => p.IsConfirmed).IsRequired();

            Property(p => p.DateBuy).IsRequired();

            HasMany(p => p.Snacks).WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("TickeId");
                    x.MapRightKey("SnackId");
                    x.ToTable("TicketSnacks");
                });
        }
    }
}
