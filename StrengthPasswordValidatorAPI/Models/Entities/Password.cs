namespace StrengthPasswordValidatorAPI.Models
{
    public class Password
    {
        public string GivenPassword { get; private set; }

        public Password(string password)
        {
            this.GivenPassword = password;
        }
    }
}
