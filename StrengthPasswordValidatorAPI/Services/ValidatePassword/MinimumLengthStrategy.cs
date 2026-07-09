using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class MinimumLengthStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (password.Length < 8)
            {
                return new PasswordNotification(false, "Password must be at least 8 characters long.");
            } else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
