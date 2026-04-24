namespace MiniSchool.Shared.Abstracts.Requests;

public abstract class BaseArchiveRequest
{
    public IList<int> Ids { get; init; }
}
