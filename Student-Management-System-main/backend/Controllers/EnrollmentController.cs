using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("enrollment")]
    public class EnrollmentController : ControllerBase
    {
        [HttpPost("enroll-student")]
        public async Task<IActionResult> EnrollStudnet([FromBody] StudentCourseMapModel enrollment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EnrollmentHelper enrollmentHelper = new EnrollmentHelper();
                    await enrollmentHelper.EnrollStudnet(enrollment);
                    return Ok($"Student Enrolled successfully.");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return BadRequest("Invalid enrollment data.");
        }

        [HttpDelete("delete-student-enrollment")]
        public async Task<IActionResult> DeleteStudentEnrollment([FromBody] StudentCourseMapModel enrollment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    EnrollmentHelper enrollmentHelper = new EnrollmentHelper();
                    await enrollmentHelper.DeleteStudentEnrollment(enrollment);
                    return Ok($"Student enrolled deleted successfully.");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            return BadRequest("Invalid enrollment data.");
        }
    }
}