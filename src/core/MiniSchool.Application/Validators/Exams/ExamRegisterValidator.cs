using FluentValidation;
using MiniSchool.Application.Dtos.Requests.Exams;

namespace MiniSchool.Application.Validators.Exams;

public sealed class ExamRegisterRequestValidator : AbstractValidator<ExamRegisterRequest>
{
    public ExamRegisterRequestValidator()
    {
        RuleFor(x => x.ExamDate)
            .NotEmpty().WithMessage("İmtahan tarixi boş ola bilməz.")
            // LessThanOrEqualTo əvəzinə Must istifadə edirik
            .Must(date => date.Date <= DateTime.Now.Date)
            .WithMessage("İmtahan tarixi gələcək bir zaman ola bilməz.");

        RuleFor(x => x.Grade)
            .InclusiveBetween((byte)0, (byte)10).WithMessage("Qiymət 0 ilə 10 arasında olmalıdır.");

        RuleFor(x => x.LessonId)
            .GreaterThan(0).WithMessage("Dərs ID düzgün deyil.");

        RuleFor(x => x.StudentId)
            .GreaterThan(0).WithMessage("Şagird ID düzgün deyil.");
    }
}
