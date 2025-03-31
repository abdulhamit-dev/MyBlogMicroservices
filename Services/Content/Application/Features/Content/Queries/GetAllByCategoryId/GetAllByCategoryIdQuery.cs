using Application.Services.Repositories;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using MediatR;

namespace Application.Features.Content.Queries.GetAllByCategoryId;

public class GetAllByCategoryIdQuery:IRequest<GetAllByCategoryIdQueryResponse>
{
    public string Id { get; set; }
    
    public class GetAllByCategoryIdQueryHandler : IRequestHandler<GetAllByCategoryIdQuery, GetAllByCategoryIdQueryResponse>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        
        public GetAllByCategoryIdQueryHandler(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }
        
        public async Task<GetAllByCategoryIdQueryResponse> Handle(GetAllByCategoryIdQuery request, CancellationToken cancellationToken)
        {
           var contents=  await _contentRepository.FindAsync(x=>x.CategoryId == request.Id);
           var contentsDto = _mapper.Map<List<ContentDto>>(contents);

           return new GetAllByCategoryIdQueryResponse
           {
               Contens = contentsDto
           };
        }
    }
}