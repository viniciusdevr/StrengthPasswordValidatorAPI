using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class RequiredLowerCaseStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            if (!password.Any(char.IsLower))
            {
                return new PasswordNotification(false, "Password must contain at least one lowercase letter.");
            }
            else
            {
                return new PasswordNotification(true);
            }
        }
    }
}
