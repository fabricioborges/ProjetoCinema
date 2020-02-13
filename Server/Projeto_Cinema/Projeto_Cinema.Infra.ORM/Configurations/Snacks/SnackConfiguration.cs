using Projeto_Cinema.Domain.Features.Snacks;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.Snacks
{
    public class SnackConfiguration : EntityTypeConfiguration<Snack>
    {
        public SnackConfiguration()
        {
            ToTable("TbSnacks");

            HasKey(i => i.Id);

            Property(p => p.Image).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.Price).IsRequired();
        }
    }
}
