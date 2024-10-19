using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommand:IRequest<UpdateCommentResponse>
{
    public Guid Id { get; set; }
    public string ContentId { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    
    public class UpdateCommentCommandHandler:IRequestHandler<UpdateCommentCommand,UpdateCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCommentResponse> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);
            comment.Text = request.Text;
            await _commentRepository.UpdateAsync(comment);
            var response = _mapper.Map<UpdateCommentResponse>(comment);
            return response;
        }
    }
}