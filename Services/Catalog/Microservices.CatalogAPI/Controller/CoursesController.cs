using Microservices.CatalogAPI.Dtos;
using Microservices.CatalogAPI.Services;
using Microservices.Contract.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.CatalogAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : MicroserviceBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAllAsync();
            return CreateResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _courseService.GetByIdAsync(id);
            return CreateResult(result);
        }

        [HttpGet("{userId}")]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var result = await _courseService.GetAllByUserIdAsync(userId);
            return CreateResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto input)
        {
            var result = await _courseService.CreateAsync(input);
            return CreateResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto input)
        {
            var result = await _courseService.UpdateAsync(input);
            return CreateResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _courseService.DeleteAsync(id);
            return CreateResult(result);
        }
    }
}
