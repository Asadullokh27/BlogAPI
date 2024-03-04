using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.RoleServices
{
    public interface IRoleService
    {
        public Task<Role> CreateRole(RoleDTO role);
        public Task<Role> UpdateRoleByName(string name, RoleDTO role);
        public Task<Role> UpdateRoleById(int id, RoleDTO role);
        public Task<bool> DeleteRoleById(int id);
        public Task<bool> DeleteRoleByName(string name);
        public Task<Role> GetRoleById(int id);
        public Task<Role> GetRoleByName(string name);
        public Task<IEnumerable<Role>> GetAllRoles();

    }
}
