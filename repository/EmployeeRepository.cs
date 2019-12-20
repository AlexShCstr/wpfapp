using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApp.domain;

namespace WpfApp.repository
{
    class EmployeeRepository : AbstractListBaseRepository<domain.Employee>, IEmployeeRepository
    {
        public bool hasEmployeesInDepartment(Department department)
        {
            return All().ToList().Find(employee => employee.department == department) != null;
        }
    }
}
