using System.Security.Cryptography;

namespace BoscComa.ADO
{
    static class Password
    {
        private const int iterations = 100000;
        private const int saltSize = 16;
        public static byte[] HashPassword(string password) {            
            return HashPassword(password, Password.GenerateSalt(), Password.iterations);
        }        
        private static byte[] GenerateSalt() {
            byte[] salt = new byte[Password.saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}