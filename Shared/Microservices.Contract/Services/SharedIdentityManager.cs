using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Microservices.Contract.Services
{
    public class SharedIdentityManager : ISharedIdentityService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "sub").FirstOrDefault().Value; // Alternative User.FindFirst("sub").Value
    }
}
