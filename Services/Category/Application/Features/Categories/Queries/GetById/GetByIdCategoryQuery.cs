using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryQuery:IRequest<GetByIdCategoryResponse>
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdCategoryResponse>(category);
        }
    }
}
