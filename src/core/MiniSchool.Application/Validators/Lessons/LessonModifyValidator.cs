using FluentValidation;
using MiniSchool.Application.Dtos.Requests.Lessons;

namespace MiniSchool.Application.Validators.Lessons;

public sealed class LessonModifyRequestValidator : AbstractValidator<LessonModifyRequest>
{
    public LessonModifyRequestValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id düzgün deyil.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Dərsin kodu boş ola bilməz.")
            .Length(3).WithMessage("Dərsin kodu tam olaraq 3 simvoldan ibarət olmalıdır.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Dərsin adı boş ola bilməz.")
            .MaximumLength(30).WithMessage("Dərsin adı maksimum 30 simvol ola bilər.");

        RuleFor(x => x.ClassLevel)
            .InclusiveBetween((byte)1, (byte)11).WithMessage("Sinif 1 ilə 11 arasında olmalıdır.");

        RuleFor(x => x.TeacherName)
            .NotEmpty().WithMessage("Müəllimin adı boş ola bilməz.")
            .MaximumLength(20).WithMessage("Müəllimin adı maksimum 20 simvol ola bilər.");

        RuleFor(x => x.TeacherSurname)
            .NotEmpty().WithMessage("Müəllimin soyadı boş ola bilməz.")
            .MaximumLength(20).WithMessage("Müəllimin soyadı maksimum 20 simvol ola bilər.");
    }
}
