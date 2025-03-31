using Application.Features.Content.Commands.Create;
using Application.Features.Content.Commands.Update;
using Application.Features.Content.Queries.GetAll;
using Application.Features.Content.Queries.GetById;
using Domain.Entities;
using AutoMapper;

namespace Application.Features.Mapping;

public class GeneralMapping:Profile
{
    public GeneralMapping()
    {
        CreateMap<Domain.Entities.Content, ContentDto>();
        CreateMap<Domain.Entities.Content, CreateContentCommand>().ReverseMap();
        CreateMap<Domain.Entities.Content, UpdateContentCommand>().ReverseMap();
        CreateMap<GetAllContentQueryResponse, ContentDto>().ReverseMap();
        CreateMap<GetByIdQueryResponse,Domain.Entities.Content>().ReverseMap();
    }
}