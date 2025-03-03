using BoscComa.GestioErrors;

namespace BoscComa.Connexio
{
    public class StringConnection
    {
        private readonly string _host;
        private readonly string _user;
        private readonly string _password;

        public StringConnection(string host, string user, string password ) 
        {
            this._host = host;
            this._user = user;
            this._password = password;
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
        public void Store(string path,string fileName,bool overwrite = false) 
        {
            try 
            {

            } 
            catch (FileException ex)
            {
                
            }
        }
    }
}