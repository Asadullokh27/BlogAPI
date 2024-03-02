using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int RoleId { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public Role Role { get; set; }

    }
}
