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
    public class StudentHelper : UserHelper
    {
        public override async Task<UserModel> GetUserDetails(int userId)
        {
            return await GetStudentDetails(userId);
        }

        private async Task<StudentModel> GetStudentDetails(int userId)
        {
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand("GetStudentDetailsById");
            StudentModel student = new StudentModel();
            
            command.Parameters.AddWithValue("@UserId", userId);
            
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    student.userName = reader["userName"].ToString();
                    student.firstName = reader["firstName"].ToString();
                    student.lastName = reader["lastName"].ToString();
                    student.userId = Convert.ToInt32(reader["userId"]);
                    student.emailId = reader["emailID"].ToString();
                    student.userType = (UserType)reader["userType"];
                    student.password = reader["password"].ToString();
                    student.contact = reader["contact"].ToString();
                    student.grade = Convert.ToInt32(reader["grade"]);
                }
            }
            await connection.CloseAsync();
            return student;
        }
    }
}