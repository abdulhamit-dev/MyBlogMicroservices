using Application.Features.Likes.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Like, CreateLikeCommand>().ReverseMap();
        CreateMap<Like, CreateLikeResponse>().ReverseMap();
    }
}