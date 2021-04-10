using Microservices.CatalogAPI.Dtos;
using Microservices.Contract.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.CatalogAPI.Services
{
    public interface ICourseService
    {
        Task<DataResult<List<CourseDto>>> GetAllAsync();
        Task<DataResult<CourseDto>> CreateAsync(CourseCreateDto courseDto);
        Task<MessageResult> UpdateAsync(CourseUpdateDto courseDto);
        Task<MessageResult> DeleteAsync(string id);
        Task<DataResult<CourseDto>> GetByIdAsync(string id);
        Task<DataResult<List<CourseDto>>> GetAllByUserIdAsync(string userId);
    }
}
