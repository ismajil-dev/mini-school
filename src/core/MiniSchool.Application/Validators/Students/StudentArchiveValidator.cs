using FluentValidation;
using MiniSchool.Application.Dtos.Requests.Students;

namespace MiniSchool.Application.Validators.Students;

public sealed class StudentArchiveRequestValidator : AbstractValidator<StudentArchiveRequest>
{
    public StudentArchiveRequestValidator()
    {
        RuleFor(x => x.Ids)
            .NotEmpty().WithMessage("Arxivləmək üçün ən azı bir qeyd seçilməlidir.");
        RuleForEach(x => x.Ids)
            .GreaterThan(0).WithMessage("Id dəyəri 0-dan böyük olmalıdır.");
    }
}
