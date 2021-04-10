using Microservices.Contract.Result;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Contract.Base
{
    public class MicroserviceBaseController : Controller
    {
        public IActionResult CreateResult<T>(DataResult<T> result)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)result.StatusCode
            };
        }

        public IActionResult CreateResult(MessageResult result)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)result.StatusCode
            };
        }
    }
}
