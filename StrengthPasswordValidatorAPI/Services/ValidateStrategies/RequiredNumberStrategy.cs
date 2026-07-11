using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class RequiredNumberStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (!password.Any(char.IsDigit))
            {
                return new PasswordNotification(StatusRuleError.DigitError, false, "Password must contain at least one number.");
            }
            else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
