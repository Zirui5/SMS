using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Utility.Database
{
    public static class DBConnection
    {
        private static readonly string connectionString = "Server=localhost, 1433\\Catalog=StudentManagementSystem;Database=StudentManagementSystem;User=SA; Password=Password123;";  
        public static string getConnectionString { get => connectionString; }  

        public static async Task<(SqlCommand, SqlConnection)> CreateConnectionReturnCommand(string spName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            SqlCommand command = new(spName, connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            return (command, connection);
        }
    }
}