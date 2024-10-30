using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("course")]
    [ApiController]
    public class CourseController(IConfiguration configuration) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration;

        [HttpPost("create")]
        public async Task<IActionResult> CreateCourse ([FromBody] CreateCouresModel course)
        {
            CourseHelper courseHelper = new CourseHelper();
            if (ModelState.IsValid)
            {
                try
                {
                    await courseHelper.CreateCourse(course);
                    return Ok($"Course created successfully.");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            else
            {
                return BadRequest("Invalid course data.");
            }

        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseModel course)
        {
            CourseHelper courseHelper = new CourseHelper();
            if (ModelState.IsValid)
            {
                try
                {
                    await courseHelper.UpdateCourse(course);
                    return Ok($"Course updated successfully.");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            return BadRequest("Invalid course data.");
        }

        [HttpGet("details")]
        public async Task<CourseModel> GetCourse([FromQuery] int courseId)
        {
            CourseHelper courseHelper = new CourseHelper();
            if (ModelState.IsValid)
            {
                try
                {
                    CourseModel course = await courseHelper.GetCourse(courseId);
                    return course;
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("Bad request");
            }

            
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCourse([FromQuery] int courseId)
        {
            CourseHelper courseHelper = new CourseHelper();
            if (ModelState.IsValid)
            {
                try
                {
                    await courseHelper.DeleteCourse(courseId);
                    return Ok($"Course deleted successfully.");
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            return BadRequest("Invalid course id.");
        }

    }
}