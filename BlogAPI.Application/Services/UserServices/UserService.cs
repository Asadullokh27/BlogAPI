using BlogAPI.Application.Abstractions;
using BlogAPI.Application.Services.Hasher;
using BlogAPI.Domain.Entities.DTOs;
using BlogAPI.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.UserServices
{
    public class UserService:IUserService
    {

        private readonly IUserRepository _usRepo;
        private readonly IHasher _psHasher;

        public UserService(IUserRepository usRepo, IHasher psHasher)
        {
            _usRepo = usRepo;
            _psHasher = psHasher;
        }

        public async Task<User> CreateUser(UserDTO usDTO)
        {
            var checker = await _usRepo.GetByAny(x => x.Login == usDTO.Login || x.Email == usDTO.Email);
            var salt = Guid.NewGuid().ToString("N");
            if (checker == null)
            {
                var password = _psHasher.Encrypt(usDTO.Password,salt);
                var res = await _usRepo.Create(new User()
                {
                    FullName = usDTO.FullName,
                    Email = usDTO.Email,
                    Login = usDTO.Login,
                    PasswordHash = password,   
                    Salt = salt
                });
                return res;
            }
            else
            {
                return new User() { };
            }
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _usRepo.Delete(x => x.Id == id);
        }

        public async Task<bool> DeleteUserByName(string name)
        {
            return await _usRepo.Delete(x => x.FullName == name);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _usRepo.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _usRepo.GetByAny(x => x.Id == id);
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _usRepo.GetByAny(x => x.Login == login);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _usRepo.GetByAny(x => x.FullName == name);
        }

        public async Task<User> UpdateUserById(int id, UserDTO usDTO)
        {
            var user = await _usRepo.GetByAny(x => x.Id == id);
            if (user == null)
            {
                return new User() { FullName = "User is not found" };
            }
            else
            {

                if (usDTO.Email != user.Email && !_usRepo.GetAll().Result.Any(x => x.Email == usDTO.Email))
                {
                    user.Email = usDTO.Email;
                }
                else
                {
                    return new User() { Email = "Email is already exists" };
                }


                if (usDTO.Login != user.Login && !_usRepo.GetAll().Result.Any(x => x.Login == usDTO.Login))
                {
                    user.Login = usDTO.Login;
                }
                else
                {
                    return new User() { Login = "Login is blocked" };
                }

                var pass = _psHasher.Encrypt(usDTO.Password, user.Salt);
                user.FullName = usDTO.FullName;
                user.Email = usDTO.Email;
                user.Login = usDTO.Login;
                user.PasswordHash = pass;
                var res = await _usRepo.Update(user);
                return res;
            }
        }

        public async Task<User> UpdateUserByName(string name, UserDTO usDTO)
        {
            var user = await _usRepo.GetByAny(x => x.FullName == name);

            if (user == null)
            {
                return new User() { FullName = "User is not found" };
            }

            if (usDTO.Email != user.Email && !_usRepo.GetAll().Result.Any(x => x.Email == usDTO.Email))
            {
                user.Email = usDTO.Email;
            }
            else
            {
                return new User() { Email = "Email is already exists" };
            }


            if (usDTO.Login != user.Login && !_usRepo.GetAll().Result.Any(x => x.Login == usDTO.Login))
            {
                user.Login = usDTO.Login;
            }
            else
            {
                return new User() { Login = "Login is blocked" };
            }

            user.FullName = usDTO.FullName;

            var pass = _psHasher.Encrypt(usDTO.Password,user.Salt);
            user.PasswordHash = pass;

            var updatedUser = await _usRepo.Update(user);

            return updatedUser;
        }


    }
}








