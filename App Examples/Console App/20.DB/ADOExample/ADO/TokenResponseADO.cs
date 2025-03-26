/// Instal·lació paquet gestió bd amb Redis
/// dotnet add package NRedisStack
/// 

using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

public class TokenResponseADO {
        private readonly IConnection _connection;
        public TokenResponseADO(IConnection connection)
        {
            _connection = connection;
        }
}