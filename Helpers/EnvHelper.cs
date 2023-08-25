using MailServices.Models;
using MailServices.Validations;

namespace MailServices.Helpers
{
    public class EnvHelper
    {
        readonly IConfiguration _config;
        public EnvHelper(IConfiguration configuration)
        {
            _config = configuration;
        }
        public EnvModel? GetEnviroments()
        {
            var env = new EnvModel()
            {
                CompanyEmail = Environment.GetEnvironmentVariable("CompanyEmail") ?? _config.GetValue<string?>("CompanyEmail"),
                CompanyName = Environment.GetEnvironmentVariable("CompanyName") ?? _config.GetValue<string?>("CompanyName"),
                CompanyPasswordEmailCredentialGoogle = Environment.GetEnvironmentVariable("CompanyPasswordEmailCredentialGoogle") ?? _config.GetValue<string?>("CompanyPasswordEmailCredentialGoogle")
            };

            var validator = new EnvModelValidation().Validate(env);
            return !validator.IsValid ? null: env;
        }
    }
}