using FluentValidation;
using MailService.Models;

namespace MailServices.Validations
{
    public class ToUserValidation : AbstractValidator<List<ToUser>>
    {
        public ToUserValidation()
        {

            RuleForEach(x => x).NotNull().NotEmpty().ChildRules((child) => {
                child.RuleFor(c => c.Nombre).NotNull().NotEmpty();
                child.RuleFor(c => c.Email).NotNull().NotEmpty().EmailAddress();
            });

        }
    }
}
