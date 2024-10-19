using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Comment,CreateCommentCommand>().ReverseMap();
        CreateMap<Comment, CreateCommentResponse>().ReverseMap();
        
        CreateMap<Comment,DeleteCommentCommand>().ReverseMap();
        CreateMap<Comment,DeleteCommentResponse>().ReverseMap();
        
        CreateMap<Comment,UpdateCommentCommand>().ReverseMap();
        CreateMap<Comment,UpdateCommentResponse>().ReverseMap();

    }
}