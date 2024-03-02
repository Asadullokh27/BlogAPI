using BlogAPI.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Persistance.Configurations
{
    public class UserConfigurations:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Email)
                .HasMaxLength(40);

            entityTypeBuilder.Property(x => x.FullName)
                .HasMaxLength(40);
        }
    }
}
