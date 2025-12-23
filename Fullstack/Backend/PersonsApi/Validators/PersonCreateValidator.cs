using FluentValidation;
using PersonsApi.Dtos;

namespace PersonsApi.Validators;

public class PersonCreateValidator : AbstractValidator<PersonCreateDto>
{
    public PersonCreateValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Document).NotEmpty().Length(6, 20);
    }
}
