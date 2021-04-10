using AutoMapper;
using Microservices.CatalogAPI.Dtos;
using Microservices.CatalogAPI.Models;
using Microservices.CatalogAPI.Types;
using Microservices.Contract.Enums;
using Microservices.Contract.Result;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.CatalogAPI.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryManager(IMapper mapper, IDatabaseSettings datababeSettings)
        {
            var client = new MongoClient(datababeSettings.MongoConnection);
            var database = client.GetDatabase(datababeSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(datababeSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<DataResult<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return DataResult<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), StatusCode.Ok);
        }

        public async Task<DataResult<CategoryDto>> Createsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);

            return DataResult<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), StatusCode.Ok);
        }

        public async Task<DataResult<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            
            if (category == null)
            {
                return DataResult<CategoryDto>.Error("Category not found", StatusCode.NotFound);
            }

            return DataResult<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), StatusCode.Ok);
        }
    }
}
