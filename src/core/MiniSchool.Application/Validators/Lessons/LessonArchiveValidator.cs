using FluentValidation;
using MiniSchool.Application.Dtos.Requests.Lessons;

namespace MiniSchool.Application.Validators.Lessons;

public sealed class LessonArchiveRequestValidator : AbstractValidator<LessonArchiveRequest>
{
    public LessonArchiveRequestValidator()
    {
        RuleFor(x => x.Ids)
            .NotEmpty().WithMessage("Arxivləmək üçün ən azı bir qeyd seçilməlidir.");
        RuleForEach(x => x.Ids)
            .GreaterThan(0).WithMessage("Id dəyəri 0-dan böyük olmalıdır.");
    }
}
