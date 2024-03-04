using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Hasher
{
    public interface IHasher
    {
        public string Encrypt(string password);
        public bool Verify(string hash, string password);

    }
}
