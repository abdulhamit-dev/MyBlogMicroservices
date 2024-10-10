using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Commands.Create;


public class CreateCategoryCommand:IRequest<CreateCategoryResponse>
{
    public string Name { get; set; }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category @event = _mapper.Map<Category>(request);
            @event.Id=Guid.NewGuid();
            await _categoryRepository.AddAsync(@event); 
            CreateCategoryResponse response =_mapper.Map<CreateCategoryResponse>(@event);
            return response;
        }
    }

}