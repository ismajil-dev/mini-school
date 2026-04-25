using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Exams;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Handlers.Exams;

public sealed class ExamRegisterRequestHandler
    (IExamCommandRepository commandRepository
    , IUnitOfWork unitOfWork) 
    : IRequestHandler<ExamRegisterRequest, ExamDto>
{


    public async Task<ExamDto> Handle(ExamRegisterRequest request, CancellationToken ct)
    {
        var entity = ExamMapper.ToEntity(request);
        await commandRepository.RegisterAsync(entity, ct);
        await unitOfWork.SaveChangesAsync();
        return ExamMapper.ToDto(entity);
    }
}
