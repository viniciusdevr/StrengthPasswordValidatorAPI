using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StrengthPasswordValidatorAPI.Models;
using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController(IValidatePasswordService validatePasswordService) : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult GetPasswordValidation([FromBody] Password password)
        {
            try
            {
                var notifications = validatePasswordService.Validate(password.GivenPassword);

                if (notifications.Count > 0)
                {
                    return BadRequest(notifications);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while validating the password.");
            }
        }


    }
}
