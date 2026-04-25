using MediatR;
using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Students;
using MiniSchool.Application.Mappers;
using MiniSchool.Application.Repositories.Queries;

namespace MiniSchool.Application.Handlers.Students;

public sealed class StudentArchiveRequestHandler
    (IStudentQueryRepository queryRepository) 
    : IRequestHandler<StudentArchiveRequest, IList<StudentDto>>
{


    public async Task<IList<StudentDto>> Handle(StudentArchiveRequest request, CancellationToken ct)
    {
        var archivedEntities = await queryRepository.QueryAll()
            .Where(s => request.Ids.Contains(s.Id))
            .ToListAsync(ct);

        await queryRepository.QueryAll()
            .Where(s => request.Ids.Contains(s.Id))
            .ExecuteUpdateAsync(s => s.SetProperty(x => x.IsArchived, true), ct);

        return archivedEntities.Select(StudentMapper.ToDto).ToList();
    }
}