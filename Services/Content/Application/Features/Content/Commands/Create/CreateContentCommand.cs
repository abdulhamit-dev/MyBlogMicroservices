using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Content.Commands.Create;

public class CreateContentCommand:IRequest<CreateContentResponse>
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string CategoryId { get; set; }
    public User User { get; set; }
    
    public class CreateContentCommandHandler:IRequestHandler<CreateContentCommand, CreateContentResponse>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        public CreateContentCommandHandler(IContentRepository contentRepository, IMapper mapper)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }
        public async Task<CreateContentResponse> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var content = _mapper.Map<Domain.Entities.Content>(request);
            
            await _contentRepository.AddAsync(content);
            
            //todo: add event bus
            // string insertedId = content.Id.ToString()
            // _textSearchService.Publish(new TextSearchContentEvent()
            // {
            //     Title = content.Title,
            //     Text = content.Text
            // });

            return new CreateContentResponse()
            {
                Id = content.Id.ToString()
            };
        }
    }
}