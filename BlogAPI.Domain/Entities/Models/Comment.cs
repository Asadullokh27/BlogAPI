using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string CreationDate { get; set; }

    }
}
