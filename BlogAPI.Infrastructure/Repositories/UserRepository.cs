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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BlogDbContext context)
            : base(context)
        {

        }
    }
}
