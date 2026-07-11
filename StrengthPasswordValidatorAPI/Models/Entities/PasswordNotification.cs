using StrengthPasswordValidatorAPI.Models.Enums;
using System.Text.Json.Serialization;

namespace StrengthPasswordValidatorAPI.Models.Entities
{
    public class PasswordNotification
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
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
