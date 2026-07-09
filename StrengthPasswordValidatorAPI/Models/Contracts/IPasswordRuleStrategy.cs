using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Models.Contracts
{
    public interface IPasswordRuleStrategy
    {
        PasswordNotification Validate(string password);
    }
}
