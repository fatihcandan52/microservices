using Microservices.CatalogAPI.Dtos;
using Microservices.CatalogAPI.Services;
using Microservices.Contract.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Microservices.CatalogAPI.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : MicroserviceBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return CreateResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return CreateResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var result = await _categoryService.Createsync(categoryDto);
            return CreateResult(result);
        }
    }
}
