using BlogAPI.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.AuthServices
{
    public interface IAuthorizationService
    {

        public Task<string> GenerateToken(LoginDTO user);

    }
}
