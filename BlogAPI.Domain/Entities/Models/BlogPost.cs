﻿using BlogAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlogAPI.Domain.Entities.Models
{
    public class BlogPost
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationDate { get; set; }
        public string Category { get; set; }
        public string FeaturedImage { get; set; }
        public Status Status { get; set; } // You might use an enum for status
        public ICollection<Comment> Comments { get; set; } // Assuming Comment is another model
        public int Likes { get; set; }
        public int Views { get; set; }

    }
}