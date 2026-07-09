using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StrengthPasswordValidatorAPI.Models;
using StrengthPasswordValidatorAPI.Models.Contracts;
using StrengthPasswordValidatorAPI.Models.Entities;

namespace StrengthPasswordValidatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordController(IValidatePasswordService validatePasswordService) : Controller
    {
        [HttpGet("validate")]
        public IActionResult GetPasswordValidation(Password password)
        {
            try
            {
                var notifications = validatePasswordService.Validate(password.GivenPassword);

                if (notifications is not null)
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
