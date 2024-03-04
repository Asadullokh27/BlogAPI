﻿using BlogAPI.Application.Abstractions;
using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.CommentServices
{
    public class CommentService:ICommentService
    {
        public ICommentRepository _comRepos;

        public CommentService(ICommentRepository comRepos)
        {
            _comRepos = comRepos;
        }

        public async Task<Comment> CreateRole(CommentDTO com)
        {
            var s = await _comRepos.Create(new Comment() { Author = com.Author, Content = com.Content, BlogPostId = com.BlogPostId });
            return s;
        }

        public async Task<bool> DeleteRoleById(int id)
        {
            var s = await _comRepos.Delete(x => x.Id == id);
            return s;
        }

        public async Task<IEnumerable<Comment>> GetAllRoles()
        {
            var all = await _comRepos.GetAll();
            return all;
        }

        public async Task<Comment> GetRoleById(int id)
        {
            var res = await _comRepos.GetByAny(x => x.Id == id);
            return res;
        }

        public async Task<Comment> UpdateRoleById(int id, CommentDTO com)
        {
            var s = await _comRepos.GetByAny(x => x.Id == id);
            if (s == null)
            {
                return new Comment() { };
            }
            else
            {
                var res = await _comRepos.Update(new Comment { Author = com.Author, Content = com.Content, BlogPostId = com.BlogPostId });
                return res;
            }
        }
    }
}
