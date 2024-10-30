using System.Security.Claims;
using backend.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Data.SqlClient;
using backend.Utility.Database;
using backend.Enums;

namespace backend.Helpers
{
    public class LoginHelper(IConfiguration configuration)
    {
        private readonly string connectionString = DBConnection.getConnectionString;
        private readonly IConfiguration? _configuration = configuration;

        public async Task<object> ProcessUserLogin(UserLoginModel user, UserType userType)
        {
            bool userExists = await CheckIfUserIsPresentAsync(user.userName, userType);
            bool isMatch = false;
            TeacherModel admin;
            TeacherModel teacher;
            StudentModel student;
            object userDetils = new();
            if (userExists)
            {
                switch (userType)
                {
                    case UserType.ADMIN:
                        admin = await GetAdminDetails(user.userName, "GetAdminDetailsByEmail");
                        isMatch = CheckIfPasswordMatch(user.password, admin.password);
                        userDetils = admin;
                        break;
                    case UserType.TEACHER:
                        teacher = await GetTeacherDetails(user.userName, "GetTeacherDetailsByEmail");
                        isMatch = CheckIfPasswordMatch(user.password, teacher.password);
                        userDetils = teacher;
                        break;
                    case UserType.STUDENT:
                        student = await GetStudentDetails(user.userName, "GetStudentDetailsByEmail");
                        isMatch = CheckIfPasswordMatch(user.password, student.password);
                        userDetils = student;
                        break;
                }

                if (isMatch)
                {
                    object token = CreateUserSession(user);
                    return (new
                    {
                        token,
                        userDetils
                    });
                }
                else
                {
                    throw new Exception("Password miss match");
                }
            }
            else
            {
                throw new Exception("User not found");
            }

        }

        private async Task<bool> CheckIfUserIsPresentAsync(string emailID, UserType userType)
        {
            string spName;
            switch (userType)
                {
                    case UserType.ADMIN:
                        spName = "CheckAdminExists";
                        break;
                    case UserType.TEACHER:
                        spName = "CheckTeacherExists";
                        break;
                    case UserType.STUDENT:
                        spName = "CheckStudentExists";
                        break;
                    default:
                        spName = "";
                        break;
                }
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                SqlCommand command = new(spName, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Email", emailID);
                
                return Convert.ToBoolean(await command.ExecuteScalarAsync());
            }
        }

        private bool CheckIfPasswordMatch(string typedPassword, string dbPassword)
        {
            return typedPassword.Equals(dbPassword);
        }

        private async Task<TeacherModel> GetAdminDetails(string emailID, string spName)
        {
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand(spName);
            TeacherModel admin = new TeacherModel();
            
            command.Parameters.AddWithValue("@Email", emailID);
            
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

        private async Task<TeacherModel> GetTeacherDetails(string emailID, string spName)
        {
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand(spName);
            TeacherModel teacher = new TeacherModel();
    
            command.Parameters.AddWithValue("@Email", emailID);
                
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    teacher.userName = reader["userName"].ToString();
                    teacher.firstName = reader["FirstName"].ToString();
                    teacher.lastName = reader["LastName"].ToString();
                    teacher.userId = Convert.ToInt32(reader["userId"]);
                    teacher.emailId = reader["emailID"].ToString();
                    teacher.userType = (UserType)reader["userType"];
                    teacher.password = reader["userPassword"].ToString();
                    teacher.contact = reader["contact"].ToString();
                }
            }
            await connection.CloseAsync();
            return teacher;
        }

        private async Task<StudentModel> GetStudentDetails(string emailID, string spName)
        {
            (SqlCommand command, SqlConnection connection) = await DBConnection.CreateConnectionReturnCommand(spName);
            StudentModel student = new StudentModel();
            
            command.Parameters.AddWithValue("@Email", emailID);
                
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                while (reader.Read())
                {
                    student.userName = reader["userName"].ToString();
                    student.firstName = reader["FirstName"].ToString();
                    student.lastName = reader["LastName"].ToString();
                    student.userId = Convert.ToInt32(reader["userId"]);
                    student.emailId = reader["emailID"].ToString();
                    student.userType = (UserType)reader["userType"];
                    student.password = reader["password"].ToString();
                    student.contact = reader["contact"].ToString();
                    student.grade =  Convert.ToInt32(reader["grade"]);
                }
            }
            await connection.CloseAsync();
            return student;
        }


        private object CreateUserSession(UserLoginModel user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            authClaims.Add(new Claim(ClaimTypes.Role, "admin"));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return (new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}