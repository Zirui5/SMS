using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using backend.Enums;
using backend.Models;
using backend.Utility.Database;

namespace backend.Helpers
{
    public class AdminDashboardHelper
    {
        public async Task<List<CourseDashboardModel>> GetAllCourseForAdminDashboard()
        {
            return await GetAllCourseFormDatabase();
        }

        private async Task<List<CourseDashboardModel>> GetAllCourseFormDatabase()
        {
            List<CourseDashboardModel> courses = new List<CourseDashboardModel>();
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand("GetCourseForAdminDashborad");
            
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    CourseDashboardModel course = new CourseDashboardModel();
                    
                    course.courseName = reader["courseName"].ToString();
                    course.courseDescription = reader["courseDescription"].ToString();
                    course.courseCode = reader["courseCode"].ToString();
                    course.maxCapacity = Convert.ToInt32(reader["maxCapacity"]);
                    course.credits = Convert.ToInt32(reader["credits"]);
                    course.totalEnrollment = Convert.ToInt32(reader["totalEnrollment"]);
                    course.teacherName = reader["teacherName"].ToString();
                    course.teacherId = Convert.ToInt32(reader["teacherId"]);
                    course.courseId = Convert.ToInt32(reader["courseId"]);
                    course.departmentId = (Department)reader["departmentId"];

                    courses.Add(course);
                }
            }
            await connection.CloseAsync();
            return courses;
        }
    }
}