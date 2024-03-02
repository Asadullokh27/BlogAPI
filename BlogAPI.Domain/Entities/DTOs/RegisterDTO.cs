using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities.DTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
    }
}
