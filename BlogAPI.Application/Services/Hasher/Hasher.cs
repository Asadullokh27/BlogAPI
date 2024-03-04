using System;
using System.Security.Cryptography;
using System.Text;

namespace BlogAPI.Application.Services.Hasher
{
    public class Hasher : IHasher
    {
        private const int KeySize = 32;
        private const int IterationsCount = 1000;

        public string Encrypt(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password: password,
                saltSize: 16,
                iterations: IterationsCount,
                hashAlgorithm: HashAlgorithmName.SHA256))
            {
                var bytes = algorithm.GetBytes(KeySize);
                return Convert.ToBase64String(bytes);
            }
        }

        public bool Verify(string hash, string password)
        {
            var computedHash = Encrypt(password);
            return ConstantTimeComparison(computedHash, hash);
        }

        private static bool ConstantTimeComparison(string computedHash, string hash)
        {
            if (computedHash.Length != hash.Length)
                return false;

            var difference = 0;
            for (var i = 0; i < computedHash.Length; i++)
                difference |= computedHash[i] ^ hash[i];

            return difference == 0;
        }
    }
}
