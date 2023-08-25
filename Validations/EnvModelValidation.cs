using FluentValidation;
using MailServices.Models;

namespace MailServices.Validations;

public class EnvModelValidation : AbstractValidator<EnvModel>{
    public EnvModelValidation()
    {
        RuleFor(x => x.CompanyEmail).NotNull().NotEmpty();
        RuleFor(x => x.CompanyName).NotNull().NotEmpty();
        RuleFor(x => x.CompanyPasswordEmailCredentialGoogle).NotNull().NotEmpty();
    }
}