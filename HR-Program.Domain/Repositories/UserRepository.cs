using HR_Program.Domain.DTO;
using HR_Program.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public bool Create(User model)
        {
            try
            {
                InsertUpdate(new User(), new SqlParameter()
                {
                    ParameterName = "@IdUser",
                    Value = model.IdUser
                }, new SqlParameter()
                {
                    ParameterName = "@FirstName",
                    Value = model.FirstName
                }, new SqlParameter()
                {
                    ParameterName = "@LastName",
                    Value = model.LastName
                }, new SqlParameter()
                {
                    ParameterName = "@PersonalNumber",
                    Value = model.PersonalNumber
                }, new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = model.Gender
                }, new SqlParameter()
                {
                    ParameterName = "@DateOfBirth",
                    Value = model.DateOfBirth
                }, new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = model.Email
                }, new SqlParameter()
                {
                    ParameterName = "@Password",
                    Value = model.Password
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Select()
        {
            DataTable myTable = GetFromView(new User());
            List<User> employeeList = new List<User>();

            foreach (DataRow row in myTable.Rows)
            {
                User user = new User()
                {
                    IdUser = Convert.ToInt32(row["IdUser"]),
                    PersonalNumber = row["PersonalNumber"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Gender = row["Gender"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    Email = row["Email"].ToString(),
                    Password = row["Password"].ToString()
                };
                employeeList.Add(user);
            }

            return employeeList;
        }

        public bool Update(User model)
        {
            return Create(model);
        }
    }
}
