using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Program.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T model);
        bool Update(T model);

        T Get(int id);

        IEnumerable<T> Select();

        bool Delete(int id);
    }
}
