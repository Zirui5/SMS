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
    [Route("admin/dasboard")]
    public class AdminDashboardController : ControllerBase
    {
        [HttpGet("course-list")]
        public async Task<List<CourseDashboardModel>> GetAllCourseForAdminDashboard()
        {
            AdminDashboardHelper adminDashboardHelper = new AdminDashboardHelper();
            try
            {
                List<CourseDashboardModel> courses = await adminDashboardHelper.GetAllCourseForAdminDashboard();
                return courses;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}