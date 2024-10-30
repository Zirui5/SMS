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
    public class AdminHelper : UserHelper
    {
        public override async Task<UserModel> GetUserDetails(int userId)
        {
            return await GetAdminDetails(userId);
        }

        private async Task<AdminModel> GetAdminDetails(int userId)
        {
            AdminModel admin = new AdminModel();
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand("GetAdminDetailsById");
            command.Parameters.AddWithValue("@UserId", userId);
            
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    admin.userName = reader["userName"].ToString();
                    admin.firstName = reader["firstName"].ToString();
                    admin.lastName = reader["lastName"].ToString();
                    admin.userId = Convert.ToInt32(reader["userId"]);
                    admin.emailId = reader["emailID"].ToString();
                    admin.userType = (UserType)reader["userType"];
                    admin.password = reader["password"].ToString();
                    admin.contact = reader["contact"].ToString();
                }
            }
                await connection.CloseAsync();
                return admin;
        }
    }
}