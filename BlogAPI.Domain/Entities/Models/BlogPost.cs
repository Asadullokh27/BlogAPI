using BlogAPI.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlogAPI.Domain.Entities.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? PublicationDate { get; set; }
        public string? Category { get; set; }
        public string? FeaturedImage { get; set; }
        public Status Status { get; set; } // You might use an enum for status
        public ICollection<Comment>? Comments { get; set; } // Assuming Comment is another model
        public int Likes { get; set; }
        public int Views { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
