using FluentValidation;
using ShalomMailService.Models;

namespace ShalomMailServices.Validations
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
