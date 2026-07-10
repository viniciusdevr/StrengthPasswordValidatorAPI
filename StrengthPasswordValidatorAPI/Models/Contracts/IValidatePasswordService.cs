using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Models.Contracts
{
    public interface IValidatePasswordService
    {
        List<PasswordNotification> Validate(string password);
    }
}
