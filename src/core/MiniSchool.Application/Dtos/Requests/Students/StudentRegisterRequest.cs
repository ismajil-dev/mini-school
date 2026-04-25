using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Shared.Abstracts.Requests;

namespace MiniSchool.Application.Dtos.Requests.Students;

public sealed class StudentRegisterRequest
    : BaseRegisterRequest
    , IRequest<StudentDto>
{
    public required string Name { get; set; } = null!;
    public required string Surname { get; set; } = null!;
    public required byte ClassLevel { get; set; }
}
