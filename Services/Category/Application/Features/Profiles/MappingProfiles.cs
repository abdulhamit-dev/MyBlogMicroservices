using Application.Features.Categories.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreateCategoryResponse>().ReverseMap();
    }
}