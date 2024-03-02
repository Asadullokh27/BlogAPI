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
    public class PermissionConfigurations:IEntityTypeConfiguration<Permission>
    {

        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(new Permission()
            {
                Id = 1,
                Name = "GetBlogPost"
            });
        }

    }
}
