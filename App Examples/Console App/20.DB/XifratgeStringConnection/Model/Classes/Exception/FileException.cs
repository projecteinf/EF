using System.IO;

namespace BoscComa.GestioErrors
{
    public class FileException : IOException
    {
        public FileException() : base() { }
        public FileException(string message) : base(message) { }
        public FileException(string message, Exception innerException): base(message, innerException) { }
    }
}