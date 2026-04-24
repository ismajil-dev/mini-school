using MiniSchool.Shared.Interfaces.Entities;

namespace MiniSchool.Shared.Abstracts.Entities;

public abstract class BaseEntity
    : IEntity
{
    public int Id { get; init; }

}