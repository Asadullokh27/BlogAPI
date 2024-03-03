using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities.DTOs
{
    public class CommentDTO
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public string CreationDate { get; set; }
        public int BlogPostId { get; set; }
    }
}
