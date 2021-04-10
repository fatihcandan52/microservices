using AutoMapper;
using Microservices.CatalogAPI.Dtos;
using Microservices.CatalogAPI.Models;
using Microservices.CatalogAPI.Types;
using Microservices.Contract.Enums;
using Microservices.Contract.Result;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.CatalogAPI.Services
{
    public class CourseManager : ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CourseManager(IMapper mapper, IDatabaseSettings datababeSettings, ICategoryService categoryService)
        {
            var client = new MongoClient(datababeSettings.MongoConnection);
            var database = client.GetDatabase(datababeSettings.DatabaseName);
            _courseCollection = database.GetCollection<Course>(datababeSettings.CategoryCollectionName);
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<DataResult<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(x => true).ToListAsync();
            return await CourseListPreparation(courses);
        }

        public async Task<DataResult<CourseDto>> CreateAsync(CourseCreateDto categoryDto)
        {
            var course = _mapper.Map<Course>(categoryDto);
            await _courseCollection.InsertOneAsync(course);

            return DataResult<CourseDto>.Success(_mapper.Map<CourseDto>(course), StatusCode.Ok);
        }

        public async Task<MessageResult> UpdateAsync(CourseUpdateDto categoryDto)
        {
            var course = _mapper.Map<Course>(categoryDto);
            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == course.Id, course);

            if (result == null)
                return MessageResult.Error("Will update data not found", StatusCode.NotFound);

            return MessageResult.Success(StatusCode.Ok);
        }

        public async Task<MessageResult> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
                return MessageResult.Success(StatusCode.OkNoContent);

            return MessageResult.Error("Will delete data not found", StatusCode.NotFound);
        }

        public async Task<DataResult<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(x => x.Id == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return DataResult<CourseDto>.Error("Course not found", StatusCode.NotFound);
            }

            return DataResult<CourseDto>.Success(_mapper.Map<CourseDto>(course), StatusCode.Ok);
        }

        public async Task<DataResult<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find(x => x.UserId == userId).ToListAsync();
            return await CourseListPreparation(courses);
        }

        private async Task<DataResult<List<CourseDto>>> CourseListPreparation(List<Course> courses)
        {
            var coursesDto = _mapper.Map<List<CourseDto>>(courses);

            if (coursesDto.Any())
            {
                foreach (var item in coursesDto)
                {
                    var result = await _categoryService.GetByIdAsync(item.CategoryId);
                    if (result.IsSuccess)
                        item.Category = result.Data;
                }
            }

            return DataResult<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), StatusCode.Ok);
        }

    }
}
