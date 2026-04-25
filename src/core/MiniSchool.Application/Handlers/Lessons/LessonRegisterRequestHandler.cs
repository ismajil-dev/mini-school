using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Lessons;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Handlers.Lessons;

public sealed class LessonRegisterRequestHandler
    (ILessonCommandRepository commandRepository
    , IUnitOfWork unitOfWork) 
    : IRequestHandler<LessonRegisterRequest, LessonDto>
{


    public async Task<LessonDto> Handle(LessonRegisterRequest request, CancellationToken ct)
    {
        var entity = LessonMapper.ToEntity(request);
        await commandRepository.RegisterAsync(entity, ct);
        await unitOfWork.SaveChangesAsync();
        return LessonMapper.ToDto(entity);
    }
}
