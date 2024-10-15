using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nucleo.DDD.Application.Pipelines.Caching;

namespace Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommand:IRequest<UpdateCategoryResponse>,ICacheRemoverRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "getCategories";

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            category.Name = request.Name;
            await _categoryRepository.UpdateAsync(category);
            var response = _mapper.Map<UpdateCategoryResponse>(category);
            return response;
        }
    }
}