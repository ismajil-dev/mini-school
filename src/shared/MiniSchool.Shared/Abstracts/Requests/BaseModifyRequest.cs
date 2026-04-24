using MiniSchool.Shared.Interfaces.Capabilities;

namespace MiniSchool.Shared.Abstracts.Requests;

public abstract class BaseModifyRequest
    : IIdentifiable
{
    public required int Id { get; init; }
}
