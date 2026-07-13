using StrengthPasswordValidatorAPI.Models.Enums;
using System.Text.Json.Serialization;

namespace StrengthPasswordValidatorAPI.Models.Entities
{
    public class PasswordNotification
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusRuleError Error { get; set; } = StatusRuleError.None;
        public string Message { get; set; } = string.Empty;

        public PasswordNotification(StatusRuleError error)
        {
            Error = error;
        }

        public PasswordNotification(StatusRuleError error, string message)
        {
            Error = error;
            Message = message;
        }

        
    }
}
