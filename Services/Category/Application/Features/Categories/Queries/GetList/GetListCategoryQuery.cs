using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Nucleo.Data.Paging;
using Nucleo.DDD.Application.Requests;
using Nucleo.DDD.Application.Responses;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery: IRequest<GetListResponse<GetListCategoryResponse>>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCategoryQueryHandler:IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryResponse>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            Paginate<Category> categories=await _categoryRepository
                .GetAllWithPagingAsync(
                    request.PageRequest.PageIndex,
                    request.PageRequest.PageSize);
            
            GetListResponse<GetListCategoryResponse> 
                getListResponse =_mapper.Map<GetListResponse<GetListCategoryResponse>>(categories);

            return getListResponse;
        }
    }
}