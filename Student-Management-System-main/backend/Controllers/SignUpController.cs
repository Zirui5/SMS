using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace backend.Controllers
{
    [Route("signup")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private SignupHelper signupHelper = new SignupHelper();
        
        [HttpPost("admin")]
        public async Task<IActionResult> Signup([FromBody] UserSignUpModel userSignupData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await signupHelper.SignupAdminUser(userSignupData);
                    return Ok($"User {userSignupData.userName} signed up successfully.");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            return BadRequest("Invalid signup data.");
        }
    }
}