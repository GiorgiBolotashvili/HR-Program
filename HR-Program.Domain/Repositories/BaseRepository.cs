using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.Repositories
{
    public class BaseRepository
    {
        protected readonly string connectionString = "Server = .\\SQLEXPRESS; Database = HR; integrated security = true;";

        public DataTable GetFromView<T>(T type)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"Select * From {type.GetType().Name}View";
                SqlCommand command = new SqlCommand(query, con);
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                dataTable.Load(command.ExecuteReader());
            }
            return dataTable;
        }

        public void InsertUpdate<T>(T type, params SqlParameter[] parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandText = $"InsertUpdate{type.GetType().Name}_sp";
                command.CommandType = CommandType.StoredProcedure;
                foreach (var p in parameters)
                {
                    command.Parameters.Add(p);
                }
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                command.ExecuteScalar();
            }
        }

        public void  Delete<T>(T type, int id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandText = $"UPDATE  {type.GetType().Name} SET IsDeleted = {1} Where Id{type.GetType().Name}={id}";
                command.CommandType = CommandType.Text;
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

               Convert.ToBoolean( command.ExecuteScalar());
            }
        }

        //public string FormatPhoneNUmber(string number)
        //{
        //    if (String.IsNullOrWhiteSpace(number))
        //        return null;

        //    List<string> arr = new List<string>();
        //    for (int i = 0; i < number.Length; i += 3)
        //    {
        //        arr.Add(number.Substring(i, 3));
        //    }
        //    return string.Join("-", arr);
        //}
    }
}
