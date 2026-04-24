using MiniSchool.Shared.Abstracts.Entities;
using MiniSchool.Shared.Interfaces.Entities;

namespace MiniSchool.Shared.Interfaces.Repositories;

public interface IGenericRepository<T>
    where T : IEntity, new()
{
}
