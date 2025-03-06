using System;
using System.Text;
using System.Security.Cryptography;
using BoscComa.GestioErrors;
using BoscComa.Xifratge;

namespace BoscComa.Connexio
{
    public class StringConnection
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _password;
        private readonly string _database;
        public StringConnection(string host, string database, string user, string password ) 
        {
            this._host = host;
            this._user = user;
            this._password = password;
            this._database = database;
        }
        public string GetHost() 
        {   
            return this._host;
        }
        public string GetUser() 
        {   
            return this._user;
        }
        public string GetPassword() 
        {   
            return this._password;
        }
        public string GetDatabase() 
        {
            return this._database;
        }

        public void Store(string path, string fileName, bool overwrite = false)
        {
            string cadena = this.GetStringConnection();
            string fullPath = Path.Combine(path, fileName);

            if (!Directory.Exists(path))
            {
                throw new FileException("El directori especificat no existeix.", TipusErrorFitxer.PathInvalid);
            }

            if (string.IsNullOrWhiteSpace(fileName) || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                throw new FileException("El nom del fitxer no és vàlid.", TipusErrorFitxer.FitxerInvalid);
            }

            if (File.Exists(fullPath) && !overwrite)
            {
                throw new FileException("El fitxer ja existeix i no es pot sobreescriure.", TipusErrorFitxer.FitxerJaExisteix);
            }

            DadesXifratgeAES xifratge = DadesXifratgeAES.XifratgeAES;
            byte[] encryptedData = XifrarCadena(cadena, xifratge.Aes);

            try
            {
                File.WriteAllBytes(fullPath, encryptedData);
                // Hem de guardar les claus per a poder desencriptar la cadena de connexió
                File.WriteAllBytes(Path.Combine(path, "Key.aes"),xifratge.GetKey());
                File.WriteAllBytes(Path.Combine(path, "IV.aes"),xifratge.GetInitializationVector());
            }
            catch (FileException ex)
            {
                throw new FileException("Error d'I/O en escriure el fitxer.", TipusErrorFitxer.Altres, ex);
            }
        }

        private byte[] XifrarCadena(string text, Aes aes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cs, Encoding.UTF8))
                    {
                        streamWriter.Write(text);
                    }
                }
                return ms.ToArray();
            }
        }
        public static string GetDecrypt(string path, string fileName) 
        {
            byte[] encryptedText = LoadEncryptedText(path,fileName);
            DadesXifratgeAES xifratge = DadesXifratgeAES.XifratgeAES;

            xifratge.Aes.Key=File.ReadAllBytes(Path.Combine(path, "Key.aes"));
            xifratge.Aes.IV=File.ReadAllBytes(Path.Combine(path, "IV.aes"));

            using (ICryptoTransform decryptor = xifratge.Aes.CreateDecryptor(xifratge.GetKey(), xifratge.GetInitializationVector()))
            {
                using (MemoryStream ms = new MemoryStream(encryptedText))
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
            }
        }
        private static byte[] LoadEncryptedText(string path, string fileName) {
            string fullPath = Path.Combine(path, fileName);

            if (!File.Exists(fullPath))
            {
                throw new FileException($"No s'ha pogut localitzar el fitxer {fullPath}.", TipusErrorFitxer.FitxerNoExisteix);
            }
            try
            {
                return File.ReadAllBytes(fullPath);
            }
            catch (FileException ex)
            {
                throw new FileException("Error d'I/O en escriure el fitxer.", TipusErrorFitxer.FitxerNoExisteix, ex);
            }
        }

        private string GetStringConnection() 
        {
            return $"Server={this._host};Database={this._database};User Id={this._user};Password={this._password};TrustServerCertificate=True";
        }
    }
}
