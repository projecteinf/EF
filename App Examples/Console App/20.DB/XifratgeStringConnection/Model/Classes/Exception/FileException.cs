using System.IO;

namespace BoscComa.GestioErrors
{
    public enum TipusErrorFitxer
    {
        PathInvalid,      
        FitxerInvalid,    
        FitxerJaExisteix,
        FitxerNoExisteix, 
        Altres            
    }
    public class FileException : IOException
    {
        public TipusErrorFitxer TipusError { get; }
        public FileException(string message, TipusErrorFitxer tipusError) : base(message)
        {
            this.TipusError = tipusError;
        }
        public FileException(string message, TipusErrorFitxer tipusError, Exception innerException) 
            : base(message, innerException)
        {
            this.TipusError = tipusError;
        }
    }
}