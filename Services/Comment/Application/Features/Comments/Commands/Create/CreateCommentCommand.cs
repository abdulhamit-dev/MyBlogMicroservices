using System.Text.Json;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Comments.Commands.Create;

public class CreateCommentCommand:IRequest<CreateCommentResponse>
{
    public string ContentId { get; set; }
    public string Text { get; set; }
    public User User { get; set; }
    
    public class CreateCommentCommandHandler:IRequestHandler<CreateCommentCommand,CreateCommentResponse>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper; 
        private readonly CapEventBus _capEventBus;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, CapEventBus capEventBus)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _capEventBus = capEventBus;
        }   

        public async Task<CreateCommentResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Comment comment = _mapper.Map<Comment>(request);
            comment.Id = Guid.NewGuid();
            comment.Text = request.Text;
            comment.User = request.User;
            comment.ContentId = request.ContentId;
            await _commentRepository.AddAsync(comment);
            _capEventBus.Publish(comment,"comment.created" );
            CreateCommentResponse response = _mapper.Map<CreateCommentResponse>(comment);
            
            return response;
        }
    }
}