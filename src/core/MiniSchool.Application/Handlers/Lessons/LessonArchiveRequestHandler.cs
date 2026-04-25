using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Lessons;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Queries;

namespace MiniSchool.Application.Handlers.Lessons;

public sealed class LessonArchiveRequestHandler
    (ILessonQueryRepository queryRepository) 
    : IRequestHandler<LessonArchiveRequest, IList<LessonDto>>
{


    public async Task<IList<LessonDto>> Handle(LessonArchiveRequest request, CancellationToken ct)
    {
        var archivedEntities = await queryRepository.QueryAll()
            .Where(l => request.Ids.Contains(l.Id))
            .ToListAsync(ct);

        await queryRepository.QueryAll()
            .Where(l => request.Ids.Contains(l.Id))
            .ExecuteUpdateAsync(s => s.SetProperty(x => x.IsArchived, true), ct);

        return archivedEntities.Select(LessonMapper.ToDto).ToList();
    }
}
