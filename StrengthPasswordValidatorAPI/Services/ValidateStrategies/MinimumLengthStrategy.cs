using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class MinimumLengthStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (password.Length < 8)
            {
                return new PasswordNotification(StatusRuleError.LengthError, false, "Password must be at least 8 characters long.");
            } else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
