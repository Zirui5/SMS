using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateClass ([FromBody] CreateClassModel classData)
        {
            ClassHelper classHelper = new ClassHelper();
            if (ModelState.IsValid)
            {
                await classHelper.CreateClass(classData);

                return Ok($"Create class successfully.");
            }

            return BadRequest("Invalid signup data.");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateClass ([FromBody] ClassModel classData)
        {
            ClassHelper classHelper = new ClassHelper();
            if (ModelState.IsValid)
            {
                await classHelper.UpdateClass(classData);

                return Ok($"Class updated successfully.");
            }

            return BadRequest("Invalid signup data.");
        }

        

        [HttpGet("details")]
        public async Task<ClassModel> GetClassDetails ([FromQuery] int classId)
        {
            ClassHelper classHelper = new ClassHelper();
            if (ModelState.IsValid)
            {
                ClassModel classData = await classHelper.GetClassDetails(classId);    
                return classData;
            }
            else
            {
                throw new Exception("Bad request");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteClass ([FromQuery] int classId)
        {
            ClassHelper classHelper = new ClassHelper();
            if (ModelState.IsValid)
            {
                await classHelper.DeleteClass(classId);
                return Ok($"Create deleted successfully.");
            }

            return BadRequest("Invalid class data.");
        }
    }
}