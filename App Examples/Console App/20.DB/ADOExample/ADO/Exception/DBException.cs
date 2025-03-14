using System.IO;

namespace BoscComa.GestioErrors
{
    public enum DBOperation
    {
        Open,
        Close
    }
    public class DBException : Exception
    {
        public DBOperation TipusOperacio { get; }
        public int ErrorCode { get; }
        public string Database { get; }
        public string Server { get; }

        public string User { get; }
        public DBException(string message, DBOperation tipusOperacio, int errorCode, string server, string database, string user) 
            : base($"{message}\nCode: {errorCode}\nOperation: {tipusOperacio}\nServidor: {server}\nBase de dades: {database}\nUsuari: {user}" )
        {
            this.TipusOperacio = tipusOperacio;
            this.ErrorCode = errorCode;
            this.Server = server;
            this.Database = database;
            this.User = user;
        }
        public DBException(string message, DBOperation tipusOperacio, int errorCode, string server, string database, string user, Exception innerException) 
            : base($"{message}\nCode: {errorCode}\nOperation: {tipusOperacio}\nServidor: {server}\nBase de dades: {database}\nUsuari: {user}" , innerException)
        {
            this.TipusOperacio = tipusOperacio;
            this.ErrorCode = errorCode;
            this.Server = server;
            this.Database = database;
            this.User = user;
        }
    }
}