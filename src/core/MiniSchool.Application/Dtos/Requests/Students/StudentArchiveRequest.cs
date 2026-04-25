using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Shared.Abstracts.Requests;

namespace MiniSchool.Application.Dtos.Requests.Students;

public sealed class StudentArchiveRequest
    : BaseArchiveRequest
    , IRequest<IList<StudentDto>>
{
}
