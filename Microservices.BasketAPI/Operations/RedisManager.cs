using StackExchange.Redis;
using System.Threading.Tasks;

namespace Microservices.BasketAPI.Operations
{
    public class RedisManager
    {
        private readonly string _host;
        private readonly int _port;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisManager(string host, int port)
        {
            _port = port;
            _host = host;
        }

        public async Task ConnectAsync() => _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
