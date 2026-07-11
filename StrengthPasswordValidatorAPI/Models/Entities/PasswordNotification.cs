using StrengthPasswordValidatorAPI.Models.Enums;

namespace StrengthPasswordValidatorAPI.Models.Entities
{
    public class PasswordNotification
    {
        public StatusRuleError Error { get; set; } = StatusRuleError.None;
        public bool IsValid { get; set; }
        public string Message { get; set; } = string.Empty;

        public PasswordNotification(bool isValid)
        {
            IsValid = isValid;
        }

        public PasswordNotification(StatusRuleError error,bool isValid, string message)
        {
            Error = error;
            IsValid = isValid;
            Message = message;
        }
    }
}
