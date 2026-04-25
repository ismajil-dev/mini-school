using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Students;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Domain.Entities;
using MiniSchool.Domain.Exceptions;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Handlers.Students;

public sealed class StudentModifyRequestHandler
    (IStudentQueryRepository queryRepository
    , IStudentCommandRepository commandRepository
    , IUnitOfWork unitOfWork) : IRequestHandler<StudentModifyRequest, StudentDto>
{


    public async Task<StudentDto> Handle(StudentModifyRequest request, CancellationToken ct)
    {
        var entity = await queryRepository.FindByIdAsync(request.Id, true, ct);
        if (entity == null) throw new GenericEntityNotFoundException<Student>(request.Id);

        StudentMapper.UpdateEntity(request, entity);
        await commandRepository.ModifyAsync(entity, ct);
        await unitOfWork.SaveChangesAsync(ct);
        return StudentMapper.ToDto(entity);
    }
}
