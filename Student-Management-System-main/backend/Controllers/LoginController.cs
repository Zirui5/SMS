using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace backend.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

        [HttpPost("admin")]
        public async Task<IActionResult> AdminLogin([FromBody] UserLoginModel user)
        {
            LoginHelper loginHelper = new LoginHelper(_configuration);
            if (ModelState.IsValid)
            {
                try
                {
                    object temp =  await loginHelper.ProcessUserLogin(user, Enums.UserType.ADMIN);
                    return Ok(temp);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            return BadRequest("Invalid signup data.");
        }

        [HttpPost("student")]
        public async Task<IActionResult> StudentLogin([FromBody] UserLoginModel user)
        {
            LoginHelper loginHelper = new LoginHelper(_configuration);
            if (ModelState.IsValid)
            {
                try
                {
                    object temp =  await loginHelper.ProcessUserLogin(user, Enums.UserType.STUDENT);
                    return Ok(temp);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            return BadRequest("Invalid signup data.");
        }

        [Authorize]
        [HttpPost("teacher")]
        public async Task<IActionResult> TeacherLogin([FromBody] UserLoginModel user)
        {
            LoginHelper loginHelper = new LoginHelper(_configuration);
            if (ModelState.IsValid)
            {
                try
                {
                    object temp =  await loginHelper.ProcessUserLogin(user, Enums.UserType.TEACHER);
                    return Ok(temp);
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