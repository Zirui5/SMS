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
    public class TeacherHelper : UserHelper
    {
        public override async Task<UserModel> GetUserDetails(int userId)
        {
            return await GetTeacherDetails(userId);
        }

        private async Task<TeacherModel> GetTeacherDetails(int userId)
        {
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand("GetTeacherDetailsById");
            TeacherModel teacher = new TeacherModel();
            
            command.Parameters.AddWithValue("@UserId", userId);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    teacher.userName = reader["userName"].ToString();
                    teacher.firstName = reader["firstName"].ToString();
                    teacher.lastName = reader["lastName"].ToString();
                    teacher.userId = Convert.ToInt32(reader["userId"]);
                    teacher.emailId = reader["emailID"].ToString();
                    teacher.userType = (UserType)reader["userType"];
                    teacher.password = reader["password"].ToString();
                    teacher.contact = reader["contact"].ToString();
                }
            }
            await connection.CloseAsync();
            return teacher;
        }
    }
}