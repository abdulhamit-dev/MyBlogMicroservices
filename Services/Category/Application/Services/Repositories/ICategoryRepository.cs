using Domain.Entities;
using Nucleo.Data;

namespace Application.Services.Repositories;

public interface ICategoryRepository: IRepository<Category,Guid>
{

}