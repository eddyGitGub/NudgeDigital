using FluentValidation;

namespace NudgeDigital.Application.Features.Brands.Command
{

    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Price)
               .GreaterThan(0).ScalePrecision(2, 6).WithMessage("{PropertyName} is must be greater than 0 with a precison of 2.");


        }
    }
}
