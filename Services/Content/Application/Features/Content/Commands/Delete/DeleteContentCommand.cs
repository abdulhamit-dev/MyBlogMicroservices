using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Content.Commands.Delete;

public class DeleteContentCommand:IRequest<DeleteContentResponse>
{
    public string Id { get; set; }
    
    public class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand, DeleteContentResponse>
    {
        private readonly IContentRepository _contentRepository;
        
        public DeleteContentCommandHandler(IContentRepository contentRepository)
        {
            _contentRepository = contentRepository;
        }
        
        public async Task<DeleteContentResponse> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var content = await _contentRepository.GetByIdAsync(Guid.Parse(request.Id));
            if (content == null) throw new Exception("Content not found");
            await _contentRepository.RemoveAsync(content);
            return new DeleteContentResponse();
        }
    }
}
