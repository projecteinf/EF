using System.Security.Cryptography;

namespace BoscComa.Connexio
{
    public class DadesXifratge
    {
        public byte[] Key { get; }
        public byte[] VectorInicialitzacio { get; }
        public DadesXifratge() 
        {
            Aes aes = Aes.Create();
            this.Key = aes.Key;
            this.VectorInicialitzacio = aes.IV;
        }
    }
}