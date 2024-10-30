using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers 
{
    [Route("user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        [HttpPost("create-student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel userSignupData)
        {
            if (ModelState.IsValid)
            {

                return Ok($"User {userSignupData.userName} signed up successfully.");
            }

            return BadRequest("Invalid signup data.");
        }

        [HttpPost("create-teacher")]
        public async Task<IActionResult> CreateTeacher([FromBody] StudentModel userSignupData)
        {
            if (ModelState.IsValid)
            {

                return Ok($"User {userSignupData.userName} signed up successfully.");
            }

            return BadRequest("Invalid signup data.");
        }

        [HttpGet("teacher-details")]
        public async Task<UserModel> GetTeacherDetails([FromQuery] int userId)
        {
            if (ModelState.IsValid)
            {
                UserHelper userhelper = new TeacherHelper();
                return await userhelper.GetUserDetails(userId);
            }
            else
            {
                throw new Exception("Bad request");
            }

        }
        [HttpGet("student-details")]
        public async Task<UserModel> GetStudentDetails([FromQuery] int userId)
        {
            if (ModelState.IsValid)
            {
                UserHelper userhelper = new StudentHelper();
                return await userhelper.GetUserDetails(userId);
            }
            else
            {
                throw new Exception("Bad request");
            }
        }
        [HttpGet("admin-details")]
        public async Task<UserModel> GetAdminDetails([FromQuery] int userId)
        {
            if (ModelState.IsValid)
            {
                UserHelper userhelper = new AdminHelper();
                return await userhelper.GetUserDetails(userId);
            }
            else
            {
                throw new Exception("Bad request");
            }

        }
        
    }
}