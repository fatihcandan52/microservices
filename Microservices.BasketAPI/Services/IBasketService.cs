using Microservices.BasketAPI.Dtos;
using Microservices.Contract.Result;
using System.Threading.Tasks;

namespace Microservices.BasketAPI.Services
{
    public interface IBasketService
    {
        Task<DataResult<BasketDto>> GetBasket(string userId);
        Task<DataResult<bool>> Delete(string userId);
        Task<DataResult<bool>> SaveOrUpdate(BasketDto basketDto);
    }
}
