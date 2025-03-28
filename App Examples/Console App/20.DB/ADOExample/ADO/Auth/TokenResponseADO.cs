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
        
        public async void Save(TokenResponse token)
        {
            
            string key = $"refresh:{token.RefreshToken}";
            IDatabase db = this._connection.GetConnection();

            await db.HashSetAsync(key, new HashEntry[]
            {
                //new HashEntry("user_id", userId),
                //new HashEntry("ip", userIp),
                new HashEntry("expires", DateTime.UtcNow.AddDays(7).ToString("o"))
            });

            await db.KeyExpireAsync(key, TimeSpan.FromDays(7));
        }

}