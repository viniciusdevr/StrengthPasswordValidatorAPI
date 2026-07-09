using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class RequiredUpperCaseStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (!password.Any(char.IsUpper))
            {
                return new PasswordNotification(false, "Password must contain at least one uppercase letter.");
            }
            else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
