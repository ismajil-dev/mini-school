using MiniSchool.Shared.Interfaces.Entities;

namespace MiniSchool.Shared.Abstracts.Entities;

public abstract class BaseActiveEntity
    : BaseEntity
    , IActiveEntity
{

    public bool IsArchived { get; set; }
}
