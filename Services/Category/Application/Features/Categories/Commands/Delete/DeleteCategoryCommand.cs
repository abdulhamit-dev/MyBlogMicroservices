using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand:IRequest<DeleteCategoryResponse>
{
    public Guid Id { get; set; }
    
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            await _categoryRepository.RemoveAsync(category);
            return _mapper.Map<DeleteCategoryResponse>(category);
        }
    }
}
