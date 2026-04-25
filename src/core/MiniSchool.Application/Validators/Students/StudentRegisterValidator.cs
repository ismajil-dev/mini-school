using FluentValidation;
using MiniSchool.Application.Dtos.Requests.Students;

namespace MiniSchool.Application.Validators.Students;

public sealed class StudentRegisterRequestValidator : AbstractValidator<StudentRegisterRequest>
{
    public StudentRegisterRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Şagirdin adı boş ola bilməz.")
            .MaximumLength(30).WithMessage("Şagirdin adı maksimum 30 simvol ola bilər.");

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Şagirdin soyadı boş ola bilməz.")
            .MaximumLength(30).WithMessage("Şagirdin soyadı maksimum 30 simvol ola bilər.");

        RuleFor(x => x.ClassLevel)
            .InclusiveBetween((byte)1, (byte)11).WithMessage("Sinif 1 ilə 11 arasında olmalıdır.");
    }
}
