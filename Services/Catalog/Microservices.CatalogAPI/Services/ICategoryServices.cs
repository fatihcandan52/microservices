using Microservices.CatalogAPI.Dtos;
using Microservices.Contract.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.CatalogAPI.Services
{
    public interface ICategoryServices
    {
        Task<DataResult<List<CategoryDto>>> GetAllAsync();
        Task<DataResult<CategoryDto>> Createsync(CategoryDto categoryDto);
        Task<DataResult<CategoryDto>> GetByIdAsync(string id);
    }
}
