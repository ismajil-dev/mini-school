using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Students;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Handlers.Students;

public sealed class StudentRegisterRequestHandler
    (IStudentCommandRepository commandRepository
    , IUnitOfWork unitOfWork) 
    : IRequestHandler<StudentRegisterRequest, StudentDto>
{


    public async Task<StudentDto> Handle(StudentRegisterRequest request, CancellationToken ct)
    {
        var entity = StudentMapper.ToEntity(request);
        await commandRepository.RegisterAsync(entity, ct);
        await unitOfWork.SaveChangesAsync(ct);
        return StudentMapper.ToDto(entity);
    }
}