using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Services.ValidatePassword
{
    public class NoRepeatedCharacterStrategy : IPasswordRuleStrategy
    {
        public PasswordNotification Validate(string password)
        {
            for (int i = 0; i < password.Length - 1; i++)
            {
                if (password[i] == password[i + 1])
                {
                    return new PasswordNotification(false, "Password must not contain repeated characters.");
                }
            }
            return new PasswordNotification(true);
        }
    }
}
