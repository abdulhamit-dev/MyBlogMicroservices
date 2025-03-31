using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Content.Queries.GetAll;

public class GetAllContentQuery:IRequest<GetAllContentQueryResponse>
{
     public class GetAllContentQueryHandler:IRequestHandler<GetAllContentQuery,  GetAllContentQueryResponse> 
     {
         private readonly IContentRepository _contentRepository;
         private readonly IMapper _mapper;

         public GetAllContentQueryHandler(IContentRepository contentRepository, IMapper mapper)
         {
             _contentRepository = contentRepository;
             _mapper = mapper;
         }

         public async Task<GetAllContentQueryResponse> Handle(GetAllContentQuery request,
             CancellationToken cancellationToken)
         {
             var contents = await _contentRepository.FindAsync(content => true);
             var response = _mapper.Map<GetAllContentQueryResponse>(contents);
             return new GetAllContentQueryResponse(){
                 Contents = response.Contents
             };
         }
     }
}