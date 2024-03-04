using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDTO userDTO);
        Task<User> UpdateUserByName(string name, UserDTO userDTO);
        Task<User> UpdateUserById(int id, UserDTO userDTO);
        Task<bool> DeleteUserById(int id);
        Task<bool> DeleteUserByName(string name);
        Task<User> GetUserById(int id);
        Task<User> GetUserByName(string name);
        Task<User> GetUserByLogin(string login);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
