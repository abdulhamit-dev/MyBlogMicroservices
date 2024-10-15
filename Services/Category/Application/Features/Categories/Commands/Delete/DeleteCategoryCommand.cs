using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Nucleo.DDD.Application.Pipelines.Caching;
using Nucleo.DDD.Application.Pipelines.Logging;

namespace Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand:IRequest<DeleteCategoryResponse>,ICacheRemoverRequest,ILoggableRequest
{
    public Guid Id { get; set; }
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "getCategories";

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
       

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            await _categoryRepository.RemoveAsync(category);
            return _mapper.Map<DeleteCategoryResponse>(category);
        }
    }
}
