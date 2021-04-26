using Microservices.BasketAPI.Dtos;
using Microservices.BasketAPI.Services;
using Microservices.Contract.Enums;
using Microservices.Contract.Result;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservices.BasketAPI.Operations
{
    public class BasketManager : IBasketService
    {
        private readonly RedisManager _redisManager;

        public BasketManager(RedisManager redisManager)
        {
            _redisManager = redisManager;
        }

        public async Task<DataResult<bool>> Delete(string userId)
        {
            var status = await _redisManager.GetDb().KeyDeleteAsync(userId);

            return status ? DataResult<bool>.Success(true, StatusCode.Ok) : DataResult<bool>.Error("Basket could not found", StatusCode.NotFound);
        }

        public async Task<DataResult<BasketDto>> GetBasket(string userId)
        {
            var basket = await _redisManager.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(basket))
            {
                return DataResult<BasketDto>.Error("Basket not found", StatusCode.NotFound);
            }

            return DataResult<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(basket), StatusCode.Ok);
        }

        public async Task<DataResult<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisManager.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? DataResult<bool>.Success(true, StatusCode.Ok) : DataResult<bool>.Error("Basket could not save or update", StatusCode.Failed);
        }
    }
}
