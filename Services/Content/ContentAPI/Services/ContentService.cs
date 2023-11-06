using System.Net;
using AutoMapper;
using ContentAPI.Models;
using ContentAPI.Models.Dtos;
using ContentAPI.Models.Settings;
using MongoDB.Driver;
using SharedLib.Dtos;

namespace ContentAPI.Services;

public class ContentService : IContentService
{
    private readonly IMongoCollection<Content> _contentCollection;
    private readonly IMapper _mapper;

    public ContentService(IDatabaseSettings databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _contentCollection = database.GetCollection<Content>(databaseSettings.ContentCollectionName);
        _mapper = mapper;
    }

    public async Task<Response<NoContent>> Create(ContentCreateDto contentCreateDto)
    {
        var content= _mapper.Map<Content>(contentCreateDto);
        await _contentCollection.InsertOneAsync(content);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }

    public async Task<Response<NoContent>> Delete(string id)
    {
        await _contentCollection.DeleteOneAsync(x => x.Id == id);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }

    public async Task<Response<List<ContentDto>>> GetAll()
    {
        var contents = await _contentCollection.FindSync(content => true).ToListAsync();
        var contentDtos=_mapper.Map<List<ContentDto>>(contents);
        return Response<List<ContentDto>>.Success(contentDtos, (int)HttpStatusCode.OK);
    }

    public async Task<Response<List<ContentDto>>> GetAllByCategoryId(string id)
    {
        var contents = await _contentCollection.FindSync(content => content.CategoryId==id).ToListAsync();
        var contentDtos=_mapper.Map<List<ContentDto>>(contents);
        return Response<List<ContentDto>>.Success(contentDtos, (int)HttpStatusCode.OK);
    }

    public async Task<Response<ContentDto>> GetById(string id)
    {
        var content = await _contentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        var contentDto=_mapper.Map<ContentDto>(content);
        return Response<ContentDto>.Success(contentDto, (int)HttpStatusCode.OK);
    }

    public async Task<Response<NoContent>> Update(ContentUpdateDto contentUpdateDto)
    {
        var content=_mapper.Map<Content>(contentUpdateDto);
        await _contentCollection.ReplaceOneAsync(content => content.Id == contentUpdateDto.Id, content);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }
}
