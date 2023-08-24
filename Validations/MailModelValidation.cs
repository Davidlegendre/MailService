using FluentValidation;
using MailService.Models;

namespace MailServices.Validations
{
    public class MailModelValidation : AbstractValidator<MailModel>
    {
        public MailModelValidation() {
            RuleFor(x => x.ToUser).NotNull().NotEmpty().ChildRules((child) =>
            {
                child.RuleForEach(c => c).NotNull().NotEmpty().ChildRules((param) =>
                {
                    param.RuleFor(c => c.Email).NotNull().NotEmpty().EmailAddress();
                    param.RuleFor(c => c.Nombre).NotNull().NotEmpty();
                });
            });
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.Body).NotNull().NotEmpty();
            RuleFor(x => x.IsHTMLBody).NotNull();
        }
    }
}
