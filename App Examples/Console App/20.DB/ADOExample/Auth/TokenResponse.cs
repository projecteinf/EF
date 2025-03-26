/// Instal·lació paquet gestió bd amb Redis
/// dotnet add package NRedisStack
/// 

using NRedisStack;
using NRedisStack.RedisStackCommands;
using StackExchange.Redis;

namespace BoscComa.ADO
{
    public class TokenResponse : ITokenResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public void Save()
        {
            ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("localhost");
            IDatabase db = connectionMultiplexer.GetDatabase();
            Console.WriteLine($"GET DATABASE {db}");
        }
    }
}