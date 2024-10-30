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
    [Route("teacher/dashboard")]
    public class TeacherDashboardController : ControllerBase
    {
        [HttpGet("course-list")]
        public async Task<List<CourseDashboardModel>> GetAllCourseForTeacherDashboard(int teacherId)
        {
            TeacherDashboardHelper teacherDashboardHelper = new TeacherDashboardHelper();
            try
            {
                List<CourseDashboardModel> courses = await teacherDashboardHelper.GetAllCourseForTeacherDashboard(teacherId);
                return courses;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}