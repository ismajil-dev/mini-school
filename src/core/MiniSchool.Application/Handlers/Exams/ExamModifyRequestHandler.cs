using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Exams;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Domain.Entities;
using MiniSchool.Domain.Exceptions;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Handlers.Exams;

public sealed class ExamModifyRequestHandler
    (IExamQueryRepository queryRepository
    , IExamCommandRepository commandRepository
    , IUnitOfWork unitOfWork
    )
    : IRequestHandler<ExamModifyRequest, ExamDto>
{
    

    public async Task<ExamDto> Handle(ExamModifyRequest request, CancellationToken ct)
    {
        var entity = await queryRepository.FindByIdAsync(request.Id, true, ct);
        if (entity == null) throw new GenericEntityNotFoundException<Exam>(request.Id); 
        ExamMapper.UpdateEntity(request, entity);
        await commandRepository.ModifyAsync(entity, ct);
        await unitOfWork.SaveChangesAsync();

        return ExamMapper.ToDto(entity);
    }
}
