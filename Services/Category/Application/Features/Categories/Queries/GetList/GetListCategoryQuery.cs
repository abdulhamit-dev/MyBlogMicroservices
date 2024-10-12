using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery: IRequest<List<GetListCategoryDto>>
{
    public class GetListCategoryQueryHandler:IRequestHandler<GetListCategoryQuery, List<GetListCategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListCategoryDto>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories= await _categoryRepository.GetAllAsync();
            var categoriesDto = _mapper.Map<List<GetListCategoryDto>>(categories);
            return categoriesDto;
        }
    }
}