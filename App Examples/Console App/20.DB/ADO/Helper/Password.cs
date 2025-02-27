using System.Security.Cryptography;

namespace BoscComa.ADO
{
    static class Password
    {
        private const int iterations = 100000;
        private const int saltSize = 16;
        
        public static byte[] GetHashPassword(string password, byte[] salt) {       

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Password.iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // 32 bytes
            }  
        }        
        public static byte[] GenerateSalt() {
            byte[] salt = new byte[Password.saltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

    }
}