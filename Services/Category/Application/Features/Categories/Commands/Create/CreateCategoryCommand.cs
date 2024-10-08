using MediatR;

namespace Application.Features.Categories.Commands.Create;


public class CreateCategoryCommand:IRequest<CreateCategoryResponse>
{
    public string Name { get; set; }


    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        public Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}