using Microservices.Contract.Base;
using Microservices.Contract.Result;
using Microservices.PhotoAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.PhotoAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhotosController : MicroserviceBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream, cancellationToken);

                    var returnPath = $"photos/{photo.FileName}";


                    var photoDto = new PhotoDto
                    {
                        Path = returnPath
                    };

                    var result = DataResult<PhotoDto>.Success(photoDto, Contract.Enums.StatusCode.Ok);

                    return CreateResult(result);
                }
            }

            var failResult = MessageResult.Error("When Image Upload An Occurrent Error", Contract.Enums.StatusCode.Failed);
            return CreateMesageResult(failResult);
        }

        [HttpDelete]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);

            if (!System.IO.File.Exists(path))
            {
                var failResult = MessageResult.Error("Will Delete Photo Not Found", Contract.Enums.StatusCode.NotFound);
                return CreateMesageResult(failResult);
            }

            System.IO.File.Delete(path);

            var successResult = MessageResult.Success(Contract.Enums.StatusCode.OkNoContent);
            return CreateMesageResult(successResult);
        }
    }
}
