using HR_Program.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace HR_Program.Repository
{
    public class UserRepository
    {
        private readonly string _connectionString;
        string connectionString = "your_connection_string_here";
        string insertQuery = "INSERT INTO Users (PersonalNumber, Name, Surname, Gender, DateOfBirth, Email, Password) VALUES (@PersonalNumber, @Name, @Surname, @Gender, @DateOfBirth, @Email, @Password)";

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        //public async Task<int> AddUser(User user)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        //        {
        //            command.Parameters.AddWithValue("@PersonalNumber", user.PersonalNumber);
        //            command.Parameters.AddWithValue("@FirstName", user.FirstName);
        //            command.Parameters.AddWithValue("@LastName", user.LastName);
        //            command.Parameters.AddWithValue("@Gender", user.Gender);
        //            command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
        //            command.Parameters.AddWithValue("@Email", user.Email);
        //            command.Parameters.AddWithValue("@Password", user.Password);

        //            connection.Open();
        //            int rowsAffected = command.ExecuteNonQuery();
        //            connection.Close();

        //            if (rowsAffected == 1)
        //            {
        //                // User was successfully inserted
        //            }
        //            else
        //            {
        //                // Something went wrong
        //            }
        //        }
        //    }
        //}
    }
}
