using AutoMapper;
using BlogModule.Domain;
using BlogModule.Services.DTOs.Query;

namespace BlogModule;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, BlogCategoryDto>().ReverseMap();
    }
}