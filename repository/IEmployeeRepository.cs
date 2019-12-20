using System;
using System.Collections.Generic;
using System.Text;
using WpfApp.domain;

namespace WpfApp.repository
{
    interface IEmployeeRepository:IRepository<Employee>
    {
        bool hasEmployeesInDepartment(Department department);
    }
}
