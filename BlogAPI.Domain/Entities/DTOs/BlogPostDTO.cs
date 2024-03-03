using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities.DTOs
{
    public class BlogPostDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int UserId { get; set; }
        public List<int> Comments { get; set; }

    }
}
