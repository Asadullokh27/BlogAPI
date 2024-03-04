using BlogAPI.Application.Abstractions;
using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.BlogPostServices
{
    public class BlogPostService:IBlogPostService
    {

        private readonly IBlogPostRepository _blogrepository;

        public BlogPostService(IBlogPostRepository blogrepo)
        {
            _blogrepository = blogrepo;
        }

        public async Task<BlogPost> CreateProduct(BlogPostDTO perDTO)
        {
            var s = await _blogrepository.Create(new BlogPost()
            {
                Title = perDTO.Title,
                Author = perDTO.Author,
                UserId = perDTO.UserId
            });
            return s;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            var x = await _blogrepository.Delete(x => x.Id == id);
            return x;
        }

        public async Task<bool> DeleteProductByName(string title)
        {
            var x = await _blogrepository.Delete(x => x.Title == title);
            return x;
        }

        public async Task<IEnumerable<BlogPost>> GetAllProducts()
        {
            return await _blogrepository.GetAll();
        }

        public async Task<BlogPost> GetProductById(int id)
        {
            return await _blogrepository.GetByAny(x => x.Id == id);
        }

        public async Task<BlogPost> GetProductByName(string title)
        {
            return await _blogrepository.GetByAny(x => x.Title == title);
        }

        public async Task<BlogPost> UpdateProductById(int id, BlogPostDTO perDTO)
        {
            var s = await _blogrepository.GetByAny(x => x.Id == id);
            if (s == null)
            {
                return new BlogPost() { };
            }
            else
            {
                var res = await _blogrepository.Update(new BlogPost { Title = perDTO.Title, Author = perDTO.Author, UserId = perDTO.UserId });
                return res;
            }
        }

        public async Task<BlogPost> UpdateProductByName(string name, BlogPostDTO perDTO)
        {
            var s = await _blogrepository.GetByAny(x => x.Title == name);
            if (s == null)
            {
                return new BlogPost() { };
            }
            else
            {
                var res = await _blogrepository.Update(new BlogPost { Title = perDTO.Title, Author = perDTO.Author, UserId = perDTO.UserId });
                return res;
            }
        }

    }
}
