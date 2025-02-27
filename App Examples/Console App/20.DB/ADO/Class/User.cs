using System;

namespace BoscComa.ADO
{
    public class User
    {
        private byte[]? _password;
        public string? Uuid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }   // Unic per a tots els usuaris
        public DateTime? DateOfBirth { get; set; }   // Guardem només la data. Visualització amb la cultura de l'usuari
        public void setPassword(string password) {

        }
        public static byte[] GetHashPassword(string password) 
        {
            return Password.GetHashPassword(password);
        }
    }
}