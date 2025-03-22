using System;

namespace BoscComa.ADO
{
    public class User
    {
        private byte[]? _hashPassword;
        private byte[]? _salt;
        public string? Uuid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }   // Unic per a tots els usuaris
        public DateTime? DateOfBirth { get; set; }   // Guardem només la data. Visualització amb la cultura de l'usuari
        public byte[] GetHashPassword()
        {
            return _hashPassword;
        }
        public byte[] GetSalt()
        {
            return _salt;
        }
        public void SetHashPassword(byte[] hash)
        {
            _hashPassword = hash;
        }
        public void SetSalt(byte[] salt)
        {
            _salt = salt;
        }
        public void SetPassword(string password) 
        {
            this._salt = Password.GenerateSalt();
            this._hashPassword = Password.GetHashPassword(password,this._salt);
        }
        public bool VerifyPassword(string password) 
        {
            string currentPassword = Convert.ToBase64String(this._hashPassword);
            string checkPassword = Convert.ToBase64String(Password.GetHashPassword(password,this._salt));
            return currentPassword.Equals(checkPassword);
        }
        public bool Login(string password)
        {
            return this.VerifyPassword(password);
        }
        public override string ToString() 
        {
            return "Name: " + this.Name + "\nPassword Base64: " + Convert.ToBase64String(this._hashPassword); 
        }
    }
}