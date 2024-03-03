using BlogAPI.Application.Abstractions;
using BlogAPI.Domain.Entities.Models;
using BlogAPI.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BlogDbContext context)
            :base(context)
        {

        }
    }
}
