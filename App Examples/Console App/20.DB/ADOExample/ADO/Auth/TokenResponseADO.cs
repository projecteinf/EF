/// Instal·lació paquet gestió bd amb Redis
/// dotnet add package NRedisStack
/// 

using BoscComa.ADO;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

public class TokenResponseADO {
        private readonly IConnection<IDatabase> _connection;
        public TokenResponseADO(IConnection<IDatabase> connection)
        {
            _connection = connection;
        }
        
        public  bool Save(TokenResponse tokenResponse)
        {
            return true;
        }
}