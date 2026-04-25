using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Lessons;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Domain.Entities;
using MiniSchool.Domain.Exceptions;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Handlers.Lessons;

public sealed class LessonModifyRequestHandler
    (ILessonQueryRepository queryRepository
    , ILessonCommandRepository commandRepository
    , IUnitOfWork unitOfWork) : IRequestHandler<LessonModifyRequest, LessonDto>
{
    

    public async Task<LessonDto> Handle(LessonModifyRequest request, CancellationToken ct)
    {
        var entity = await queryRepository.FindByIdAsync(request.Id, true, ct);
        if (entity == null) throw new GenericEntityNotFoundException<Lesson>(request.Id);

        LessonMapper.UpdateEntity(request, entity);
        await commandRepository.ModifyAsync(entity, ct);
        await unitOfWork.SaveChangesAsync(ct);
        return LessonMapper.ToDto(entity);
    }
}