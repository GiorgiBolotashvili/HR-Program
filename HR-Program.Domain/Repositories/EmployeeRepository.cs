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
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public bool Create(Employee model)
        {
            int id = model.IdEmployee == null ? 0 : model.IdEmployee;

            InsertUpdate(new Employee(), new SqlParameter()
            {
                ParameterName = "@IdEmployee",
                Value = id
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
                ParameterName = "@Phone",
                Value = model.Phone
            }, new SqlParameter()
            {
                ParameterName = "@Status",
                Value = model.Status
            }, new SqlParameter()
            {
                ParameterName = "@DateOfBirth",
                Value = model.DateOfBirth
            }, new SqlParameter()
            {
                ParameterName = "@LeaveDate",
                Value = model.LeaveDate
            }); 
            throw new NotImplementedException();
        }

        public bool Delete(Employee model)
        {
            bool result = false;
            try
            {
               result = Delete(new Employee(), model.IdEmployee);
            }
            catch (Exception ex)
            {

                return false;
            }

            return result;
        }

        public Employee Get(int id)
        {
            return Select().Where(x => x.IdEmployee == id ).FirstOrDefault();
        }

        public Employee GetByPersonalNumber(string personalNumber)
        {
            return Select().Where(x => x.PersonalNumber.Equals(personalNumber)).FirstOrDefault();
        }

        public IEnumerable<Employee> Select()
        {
            DataTable myTable = GetFromView(new Employee());
            List<Employee> employeeList = new List<Employee>();

            foreach (DataRow row in myTable.Rows)
            {
                Employee employee = new Employee()
                {
                    IdEmployee = Convert.ToInt32(row["IdEmployee"]),
                    PersonalNumber = row["PersonalNumber"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Gender = row["Gender"].ToString(),
                    DateOfBirth = Convert.ToDateTime( row["DateOfBirth"]),
                    LeaveDate = typeof( DBNull ).Equals(row["LeaveDate"].GetType()) ? null :  Convert.ToDateTime( row["LeaveDate"]),
                    IdStatus = Convert.ToInt32(row["IdStatus"]),
                    Status = row["Status"].ToString(),
                    Phone = row["Phone"].ToString()
                };
                employeeList.Add(employee);
            }

            return employeeList;
        }
    }
}
