using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class RequiredNumberStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (!password.Any(char.IsDigit))
            {
                return new PasswordNotification(false, "Password must contain at least one number.");
            }
            else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
