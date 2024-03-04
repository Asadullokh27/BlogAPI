using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.PermissionServices
{
    public interface IPermissionService
    {
        Task<Permission> CreatePermission(PermissionDTO permissionDTO);
        Task<Permission> UpdatePermissionByName(string name, PermissionDTO permissionDTO);
        Task<Permission> UpdatePermissionById(int id, PermissionDTO permissionDTO);
        Task<bool> DeletePermissionById(int id);
        Task<bool> DeletePermissionByName(string name);
        Task<Permission> GetPermissionById(int id);
        Task<Permission> GetPermissionByName(string name);
        Task<IEnumerable<Permission>> GetAllPermissions();
    }
}
