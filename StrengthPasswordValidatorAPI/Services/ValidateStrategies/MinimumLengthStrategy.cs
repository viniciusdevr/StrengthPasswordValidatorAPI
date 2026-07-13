using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class MinimumLengthStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (password.Length < 9)
            {
                return new PasswordNotification(StatusRuleError.LengthError, "Password must be at least 9 characters long.");
            } else
            {
                return new PasswordNotification(StatusRuleError.None);
            }
        }
    }
}
