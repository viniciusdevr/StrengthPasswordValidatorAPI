namespace StrengthPasswordValidatorAPI.Models.Entities
{
    public class Password
    {
        public string GivenPassword { get; private set; }

        public Password(string givenPassword)
        {
            GivenPassword = givenPassword;
        }
    }
}
