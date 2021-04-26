using Microservices.BasketAPI.Dtos;
using Microservices.BasketAPI.Services;
using Microservices.Contract.Base;
using Microservices.Contract.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.BasketAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketsController : MicroserviceBaseController
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _identityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService identityService)
        {
            _basketService = basketService;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateResult(await _basketService.GetBasket(_identityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            return CreateResult(await _basketService.SaveOrUpdate(basketDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return CreateResult(await _basketService.Delete(_identityService.GetUserId));
        }
    }
}
