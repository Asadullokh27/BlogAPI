﻿using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.CommentServices
{
    public interface ICommentService
    {
        public Task<Comment> CreateRole(CommentDTO com);
        public Task<Comment> UpdateRoleById(int id, CommentDTO com);
        public Task<bool> DeleteRoleById(int id);
        public Task<Comment> GetRoleById(int id);
        public Task<IEnumerable<Comment>> GetAllRoles();

    }
}
