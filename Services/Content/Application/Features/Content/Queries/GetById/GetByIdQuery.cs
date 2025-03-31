using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Content.Queries.GetById;

public class GetByIdQuery:IRequest<GetByIdQueryResponse>
{
    public string Id { get; set; }
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdQueryResponse>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdQueryResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetByIdAsync(Guid.Parse(request.Id));
            
            var response = _mapper.Map<GetByIdQueryResponse>(content);

            return response;
        }
    }
}