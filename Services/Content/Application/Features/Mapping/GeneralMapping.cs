using Application.Features.Content.Queries.GetAll;
using Domain.Entities;
using AutoMapper;

namespace Application.Features.Mapping;

public class GeneralMapping:Profile
{
    public GeneralMapping()
    {
        CreateMap<Domain.Entities.Content, ContentDto>();
    }
}