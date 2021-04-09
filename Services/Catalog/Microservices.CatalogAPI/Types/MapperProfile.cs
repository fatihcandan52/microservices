using AutoMapper;
using Microservices.CatalogAPI.Dtos;
using Microservices.CatalogAPI.Models;

namespace Microservices.CatalogAPI.Types
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
