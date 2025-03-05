using System.Security.Cryptography;

/***
    APLICACIÓ PATRO SINGLETON PER TAL DE NOMÉS TENIR UNA INSTÀNCIA PER A XIFRATGE I DESXIFRATGE
***/
namespace BoscComa.Xifratge 
{
    public class DadesXifratgeAES : IDadesXifratge
    {
        private static DadesXifratgeAES _xifratgeAES;
        private static readonly object _bloqueig = new object();
        public Aes Aes { get; private set; }

        private DadesXifratgeAES()  // El fem privat per tal que les instàncies només es puguin crear dins de la classe.
        {
            Aes = Aes.Create();
        }
        public static DadesXifratgeAES XifratgeAES
        {
            get
            {
                return _xifratgeAES != null ? _xifratgeAES : (_xifratgeAES = new DadesXifratgeAES()); //  return _xifratgeAES ??= new DadesXifratgeAES();
            }
        }
        public byte[] GetKey() => Aes.Key;
        public byte[] GetInitializationVector() => Aes.IV;
    }
}
