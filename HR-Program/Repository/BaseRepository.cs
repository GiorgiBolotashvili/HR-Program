using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HR_Program.Repository
{
    public class BaseRepository
    {
        protected readonly string connectionString = "Server = .\\SQLEXPRESS; Database = MedsoftDT; integrated security = true;";

        public DataTable GetAllObjects<T>(T type)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = $"Exec SelectAll{type.GetType().Name}_sp";
                SqlCommand command = new SqlCommand(query, con);
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                dataTable.Load(command.ExecuteReader());
            }
            return dataTable;
        }

        public void InserUpdate<T>(T type, params SqlParameter[] parameters)
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

        public void Delete<T>(T type, int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = con.CreateCommand();
                command.CommandText = $"Delete{type.GetType().Name}_sp";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter { ParameterName = "@ID", Value = id });
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                command.ExecuteScalar();
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
