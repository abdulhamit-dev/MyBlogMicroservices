using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Commands.Delete;

public class DeleteCommentCommand:IRequest<DeleteCommentResponse>
{
    public Guid Id { get; set; }
    public class DeleteCommentCommandHandler:IRequestHandler<DeleteCommentCommand,DeleteCommentResponse>
    {
        private readonly ICommentRepository _commendRepository;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(ICommentRepository commendRepository, IMapper mapper)
        {
            _commendRepository = commendRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCommentResponse> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commendRepository.GetByIdAsync(request.Id);
            await _commendRepository.RemoveAsync(comment);
            return _mapper.Map<DeleteCommentResponse>(comment);
        }
    }
}