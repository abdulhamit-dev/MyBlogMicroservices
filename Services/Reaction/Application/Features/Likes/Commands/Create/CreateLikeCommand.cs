using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand:IRequest<CreateLikeResponse>
{
    public User User { get; set; }
    public string ContentId { get; set; }
    
    public class CreateLikeCommandHandler:IRequestHandler<CreateLikeCommand,CreateLikeResponse>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper; 
        private readonly CapEventBus _capEventBus;

        public CreateLikeCommandHandler(ILikeRepository likeRepository, IMapper mapper, CapEventBus capEventBus)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _capEventBus = capEventBus;
        }   

        public async Task<CreateLikeResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            var like = _mapper.Map<Like>(request);
            like.Id = Guid.NewGuid();
            like.User = request.User;
            like.ContentId = request.ContentId;
            await _likeRepository.AddAsync(like);
            _capEventBus.Publish(like,"like.created" );
            var response = _mapper.Map<CreateLikeResponse>(like);
            return response;
        }
    }
}