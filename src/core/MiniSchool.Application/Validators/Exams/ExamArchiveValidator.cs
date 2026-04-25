using FluentValidation;
using MiniSchool.Application.Dtos.Requests.Exams;

namespace MiniSchool.Application.Validators.Exams;

public sealed class ExamArchiveRequestValidator : AbstractValidator<ExamArchiveRequest>
{
    public ExamArchiveRequestValidator()
    {
        RuleFor(x => x.Ids)
            .NotEmpty().WithMessage("Arxivləmək üçün ən azı bir qeyd seçilməlidir.");
        RuleForEach(x => x.Ids)
            .GreaterThan(0).WithMessage("Id dəyəri 0-dan böyük olmalıdır.");
    }
}
