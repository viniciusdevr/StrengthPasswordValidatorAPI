namespace StrengthPasswordValidatorAPI.Models.Entities
{
    public class PasswordNotification
    {
        public bool IsValid { get; set; }
        public string Message { get; set; } = string.Empty;

        public PasswordNotification(bool isValid)
        {
            IsValid = isValid;
        }

        public PasswordNotification(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}
