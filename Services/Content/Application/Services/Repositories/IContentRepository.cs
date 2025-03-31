using Domain.Entities;
using Nucleo.Data;

namespace Application.Services.Repositories;

public interface IContentRepository: IRepository<Content,Guid>
{
    
}