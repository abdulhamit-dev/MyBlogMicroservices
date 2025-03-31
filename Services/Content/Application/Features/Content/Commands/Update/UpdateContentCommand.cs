using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Content.Commands.Update;

public class UpdateContentCommand:IRequest<UpdateContentResponse>
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    public string UserId { get; set; }

    public class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, UpdateContentResponse>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        
        public UpdateContentCommandHandler(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }
        
        public async Task<UpdateContentResponse> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var content = _mapper.Map<Domain.Entities.Content>(request);
            await _contentRepository.UpdateAsync(content);
            return new UpdateContentResponse();
        }
    }
}