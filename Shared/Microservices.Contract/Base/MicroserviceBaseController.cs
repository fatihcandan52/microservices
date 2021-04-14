using Microservices.Contract.Result;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Contract.Base
{
    public class MicroserviceBaseController : Controller
    {
        protected IActionResult CreateResult<T>(DataResult<T> result)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)result.StatusCode
            };
        }

        protected IActionResult CreateMesageResult(MessageResult result)
        {
            return new ObjectResult(result)
            {
                StatusCode = (int)result.StatusCode
            };
        }
    }
}
