using HR_Program.Domain.DTO;
using HR_Program.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        public bool Create(Employee model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Employee model)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Select()
        {
            throw new NotImplementedException();
        }
    }
}
