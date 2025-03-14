using System.IO;

namespace BoscComa.GestioErrors
{
    public enum Operation
    {
        Create,      
        Update,    
        Read,
        Delete            
    }
    public class CRUDException : Exception
    {
        public Operation TipusOperacio { get; }
        public int ErrorCode { get; }
        public string TableName { get; }
        public CRUDException(string message, Operation tipusOperacio, int errorCode, string tableName) 
            : base($"{message}\nCode: {errorCode}\nOperation: {tipusOperacio}\nTaula: {tableName}" )
        {
            this.TipusOperacio = tipusOperacio;
            this.ErrorCode = errorCode;
            this.TableName = tableName;
        }
        public CRUDException(string message, Operation tipusOperacio, int errorCode, string tableName, Exception innerException) 
            : base($"{message}\nCode: {errorCode}\nOperation: {tipusOperacio}\nTaula: {tableName}" , innerException)
        {
            this.TipusOperacio = tipusOperacio;
            this.ErrorCode = errorCode;
            this.TableName = tableName;
        }
    }
}