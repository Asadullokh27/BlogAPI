using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Domain.Entities.DTOs
{
    public class RoleDTO
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }
}
