using HR_Program.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.ViewModels
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public string SearchString { get; set; }
        public int Page { get; set; }
        public int RowsPerPage { get; set; }
        public int TotalPages { get; set; }
    }
}
