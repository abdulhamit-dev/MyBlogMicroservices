using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
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
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdateCategoryResponse>().ReverseMap();
        CreateMap<Category, DeleteCategoryResponse>().ReverseMap();
        CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();
        CreateMap<Category, GetListCategoryResponse>().ReverseMap();

    }
}