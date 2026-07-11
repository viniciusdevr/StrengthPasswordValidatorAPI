using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class RequiredUpperCaseStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (!password.Any(char.IsUpper))
            {
                return new PasswordNotification(StatusRuleError.UppercaseError, false, "Password must contain at least one uppercase letter.");
            }
            else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
