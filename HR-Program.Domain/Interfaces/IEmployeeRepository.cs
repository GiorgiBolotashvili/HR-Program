using HR_Program.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Employee GetByPersonalNumber(string PersonalNumber);
    }
}
