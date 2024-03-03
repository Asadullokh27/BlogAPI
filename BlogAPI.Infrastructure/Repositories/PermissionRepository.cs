using BlogAPI.Application.Abstractions;
using BlogAPI.Domain.Entities.Models;
using BlogAPI.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Repositories
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(BlogDbContext context)
            : base(context)
        {

        }
    }
}
