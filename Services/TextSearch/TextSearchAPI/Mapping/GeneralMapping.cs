using AutoMapper;
using TextSearchAPI.Models;
using TextSearchAPI.Models.Dtos;

namespace TextSearchAPI.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<TextSearchContentEvent, Content>().ReverseMap();
    }
}
