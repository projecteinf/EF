using System.Security.Cryptography;

namespace BoscComa.Connexio
{
    public class DadesXifratgeAES: IDadesXifratge
    {
        public byte[] Key { get; }
        public byte[] VectorInicialitzacio { get; }
        public DadesXifratgeAES() 
        {
            using (Aes aes = Aes.Create())
            {
                this.Key = aes.Key;
                this.VectorInicialitzacio = aes.IV;
            }
        }
    }
}