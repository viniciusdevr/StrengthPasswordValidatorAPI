namespace StrengthPasswordValidatorAPI.Models.Enums
{
    public enum StatusRuleError
    {
        None = 0,
        LengthError = 1,
        UppercaseError = 2,
        LowercaseError = 3,
        DigitError = 4,
        SpecialCharacterError = 5,
        RepeatedCharacterError = 6
    }
}
