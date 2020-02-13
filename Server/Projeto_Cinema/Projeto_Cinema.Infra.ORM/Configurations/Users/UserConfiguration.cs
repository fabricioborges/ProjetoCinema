using Projeto_Cinema.Domain.Features.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Cinema.Infra.ORM.Configurations.Users
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("TbUsers");

            HasKey(i => i.Id);

            Property(p => p.Name).IsRequired();
            Property(p => p.Email).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.AccessLevel).IsRequired();
        }
    }
}
