using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreateCategoryResponse>().ReverseMap();
        CreateMap<Category, GetListCategoryDto>().ReverseMap();
    }
}