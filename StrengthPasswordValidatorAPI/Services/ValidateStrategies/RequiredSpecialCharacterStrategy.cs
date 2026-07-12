using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class RequiredSpecialCharacterStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return new PasswordNotification(StatusRuleError.SpecialCharacterError, "Password must contain at least one special character.");
            }
            else
            {
                return new PasswordNotification(StatusRuleError.None);
            }
        }
    }
}
