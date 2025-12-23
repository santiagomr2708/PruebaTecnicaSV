using FluentValidation;
using PersonsApi.Dtos;

namespace PersonsApi.Validators;

public class PersonUpdateValidator : AbstractValidator<PersonUpdateDto>
{
    public PersonUpdateValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
