using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Shared.Abstracts.Requests;

namespace MiniSchool.Application.Dtos.Requests.Exams;

public sealed class ExamArchiveRequest
    : BaseArchiveRequest
    , IRequest<IList<ExamDto>>
{

}
