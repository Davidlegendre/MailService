using FluentValidation;
using Newtonsoft.Json;
using ShalomMailService.Models;
using ShalomMailServices.Models;

namespace ShalomMailServices.Validations
{
    public class MailModelForFromValidation : AbstractValidator<MailModelForFrom>
    {
        public MailModelForFromValidation()
        {
            RuleFor(x => x.ToUser).NotNull().NotEmpty().Custom((x, context) =>
            {
                try
                {
                    var obj = JsonConvert.DeserializeObject<List<ToUser>>(x);
                    var valid = new ToUserValidation().Validate(obj);
                    if (!valid.IsValid)
                    {
                        foreach (var item in valid.Errors)
                        {
                            context.AddFailure(item);
                        }
                    }
                }
                catch (Exception)
                {
                    context.AddFailure("ToUser no tiene el formato correcto, no se asemeja al Modelo ToUser de la api, recuerde que es una lista");
                }
            });
            RuleFor(x => x.Subject).NotNull().NotEmpty();
            RuleFor(x => x.Body).NotNull().NotEmpty();
            RuleFor(x => x.IsHTMLBody).NotNull();
        }
    }
}
