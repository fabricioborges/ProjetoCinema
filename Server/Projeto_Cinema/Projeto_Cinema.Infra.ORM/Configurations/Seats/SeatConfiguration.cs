using Projeto_Cinema.Domain.Features.Seats;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.Seats
{
    public class SeatConfiguration : EntityTypeConfiguration<Seat>
    {
        public SeatConfiguration()
        {
            ToTable("TbSeats");

            HasKey(i => i.Id);

            Property(p => p.Number).IsRequired();
            Property(p => p.IsAvailable).IsRequired();
        }
    }
}
