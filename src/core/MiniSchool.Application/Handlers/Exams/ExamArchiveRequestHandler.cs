using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Exams;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Queries;

namespace MiniSchool.Application.Handlers.Exams;

public sealed class ExamArchiveRequestHandler
    (IExamQueryRepository queryRepository) 
    : IRequestHandler<ExamArchiveRequest, IList<ExamDto>>
{
    

    public async Task<IList<ExamDto>> Handle(ExamArchiveRequest request, CancellationToken ct)
    {
        var archivedEntities = await queryRepository.QueryAll()
            .Where(e => request.Ids.Contains(e.Id))
            .ToListAsync(ct);

        await queryRepository.QueryAll()
            .Where(e => request.Ids.Contains(e.Id))
            .ExecuteUpdateAsync(s => s.SetProperty(x => x.IsArchived, true), ct);

        

        return archivedEntities.Select(ExamMapper.ToDto).ToList();
    }
}