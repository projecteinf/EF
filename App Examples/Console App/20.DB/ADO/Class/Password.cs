using System.Security.Cryptography;

namespace BoscComa.ADO
{
    static class Password
    {
        private const int size = 100000;

        private static byte[] GenerateSalt() {
            byte[] salt = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}