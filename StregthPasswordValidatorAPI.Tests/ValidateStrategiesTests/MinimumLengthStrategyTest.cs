using StrengthPasswordValidatorAPI.Models.Entities;
using StrengthPasswordValidatorAPI.Models.Enums;
using StrengthPasswordValidatorAPI.Services.ValidatePassword;

namespace StregthPasswordValidatorAPI.Tests.ValidateStrategiesTests
{
    public class MinimumLengthStrategyTest
    {
        [Theory]
        [InlineData("Abcf@567")]
        public void Validate_WhenPasswordHasNoMinimumLength_ShouldThrowLengthError(string testPassword)
        {
            // Arrange
            var validator = new MinimumLengthStrategy();
            PasswordNotification expectedNotification = new PasswordNotification(StatusRuleError.LengthError);

            // Act
            PasswordNotification isValid = validator.Validate(testPassword);

            // Assert
            Assert.Equal(expectedNotification.Error, isValid.Error);
        }

        [Theory]
        [InlineData("Abcf@5678")]
        public void Validate_WhenPasswordHasAcceptedLength_ShouldThrowNone(string testPassword)
        {
            // Arrange
            var validator = new MinimumLengthStrategy();
            PasswordNotification expectedNotification = new PasswordNotification(StatusRuleError.None);

            // Act
            PasswordNotification isValid = validator.Validate(testPassword);

            // Assert
            Assert.Equal(expectedNotification.Error, isValid.Error);
        }
    }
}
