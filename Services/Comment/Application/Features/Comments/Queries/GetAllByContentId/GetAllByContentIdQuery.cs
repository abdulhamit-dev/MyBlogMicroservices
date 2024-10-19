using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Queries.GetAllByContentId;

public class GetAllByContentIdQuery:IRequest<GetAllByContentIdResponse>
{
    public string contentId { get; set; }

    public class GetAllByContentIdQueryHandler : IRequestHandler<GetAllByContentIdQuery, GetAllByContentIdResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetAllByContentIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetAllByContentIdResponse> Handle(GetAllByContentIdQuery request,
            CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByContentIdAsync(request.contentId);
            var response = _mapper.Map<GetAllByContentIdResponse>(comment);
            return response;
        }
    }
}