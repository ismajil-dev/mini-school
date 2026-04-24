using MiniSchool.Shared.Interfaces.Entities;

namespace MiniSchool.Domain.Exceptions;

public class GenericEntityNotFoundException<TEntity> : Exception
    where TEntity : IEntity, new()
{
    public GenericEntityNotFoundException(int id)
        : base($"{typeof(TEntity).Name} not found! Id: {id}")
    {
    }
}
