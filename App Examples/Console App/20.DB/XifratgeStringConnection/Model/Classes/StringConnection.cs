using BoscComa.GestioErrors;

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
        public void Store(string path,string fileName,bool overwrite = false) 
        {
            string cadena = this.GetStringConnection();
            try 
            {
                
            } 
            catch (FileException ex)
            {
                
            }
        }
        private string GetStringConnection() 
        {
            return $"Server={this._host};Database={this._database};User Id={this._user};Password={this._password};TrustServerCertificate=True";
        }
    }
}