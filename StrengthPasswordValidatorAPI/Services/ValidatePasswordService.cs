using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;
using StrengthPasswordValidatorAPI.Services.ValidatePassword;

namespace StrengthPasswordValidatorAPI.Services
{
    public class ValidatePasswordService : IValidatePasswordService
    {
        public List<PasswordNotification> Validate(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }

            List<PasswordNotification> result = new List<PasswordNotification>();

            PasswordNotification notification = new PasswordNotification(StatusRuleError.None);

            List<IPasswordRuleStrategy> strategies = new List<IPasswordRuleStrategy>
            {
                new MinimumLengthStrategy(),
                new RequiredNumberStrategy(),
                new RequiredUpperCaseStrategy(),
                new RequiredLowerCaseStrategy(),
                new RequiredSpecialCharacterStrategy(),
                new NoRepeatedCharacterStrategy()
            };

            foreach (var strategy in strategies)
            {
                notification = strategy.Validate(password);
                if (notification.Error != StatusRuleError.None)
                {
                    result.Add(notification);
                }
            }
            return result;
        }
    }
}
