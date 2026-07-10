namespace StrengthPasswordValidatorAPI.DTOs
{
    public class PasswordNotificationDTO
    {
        public string Message { get; set; } = string.Empty;

        public PasswordNotification(bool isValid)
        {
            IsValid = isValid;
        }
    }
}
