using Domain.Entities;
using Nucleo.Data;

namespace Application.Services.Repositories;

public interface ICommentRepository:IRepository<Comment,Guid>
{
    
}