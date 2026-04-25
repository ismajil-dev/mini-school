using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Shared.Abstracts.Requests;

namespace MiniSchool.Application.Dtos.Requests.Lessons;

public sealed class LessonArchiveRequest
    : BaseArchiveRequest
    , IRequest<IList<LessonDto>>
{

}
