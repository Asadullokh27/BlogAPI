﻿using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.BlogPostServices
{
    public interface IBlogPostService
    {
        public Task<BlogPost> CreateProduct(BlogPostDTO perDTO);
        public Task<BlogPost> UpdateProductByName(string name, BlogPostDTO perDTO);
        public Task<BlogPost> UpdateProductById(int id, BlogPostDTO perDTO);
        public Task<bool> DeleteProductById(int id);
        public Task<bool> DeleteProductByName(string name);
        public Task<BlogPost> GetProductById(int id);
        public Task<BlogPost> GetProductByName(string name);
        public Task<IEnumerable<BlogPost>> GetAllProducts();

    }
}
