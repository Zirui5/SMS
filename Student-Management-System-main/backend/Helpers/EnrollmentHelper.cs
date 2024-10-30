using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Utility.Database;

namespace backend.Helpers
{
    public class EnrollmentHelper
    {
        public async Task EnrollStudnet(StudentCourseMapModel enrollment)
        {
            await InsertOrDeleteEnrollmentInDatabase(enrollment, "EnrollStudentInCourse");
        }

        public async Task DeleteStudentEnrollment(StudentCourseMapModel enrollment)
        {
            await InsertOrDeleteEnrollmentInDatabase(enrollment, "DeleteStudentEnrollment");
        }

        private static async Task InsertOrDeleteEnrollmentInDatabase(StudentCourseMapModel enrollment, string spName)
        {
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand(spName);
            StudentModel student = new StudentModel();

            command.Parameters.AddWithValue("@studentId", enrollment.studentId);
            command.Parameters.AddWithValue("@courseId", enrollment.courseId);
            await command.ExecuteNonQueryAsync();
            await connection.CloseAsync();
        }
    }
}