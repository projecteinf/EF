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

            try
            {
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

                // 🔐 Xifrar la cadena de connexió
                var xifratge = DadesXifratgeAES.XifratgeAES;
                byte[] encryptedData = XifrarCadena(cadena, xifratge.Aes);

                // 📝 Escriure el fitxer
                File.WriteAllBytes(fullPath, encryptedData);
            }
            catch (FileException ex)
            {
                Console.WriteLine($"Error de fitxer ({ex.TipusError}): {ex.Message}");
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine($"Error de xifratge: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error desconegut: {ex.Message}");
            }
        }


        private byte[] XifrarCadena(string text, Aes aes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs, Encoding.UTF8))
                    {
                        sw.Write(text);
                    }
                }
                return ms.ToArray();
            }
        }

        private string GetStringConnection() 
        {
            return $"Server={this._host};Database={this._database};User Id={this._user};Password={this._password};TrustServerCertificate=True";
        }
    }
}




