using System.Security.Cryptography;

namespace BoscComa.ADO
{
    static class Password
    {
        private const int ITERATIONS = 100000;
        private const int SALT_SIZE = 16;
        private const int PASSWORD_HASH_SIZE = 16;
        
        public static byte[] GetHashPassword(string password, byte[] salt) {       

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Password.ITERATIONS, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(PASSWORD_HASH_SIZE); 
            }  
        }        
        public static byte[] GenerateSalt() {
            byte[] salt = new byte[Password.SALT_SIZE];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

    }
}