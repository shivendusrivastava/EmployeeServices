using System;
using System.Collections.Generic;

namespace Employee.DataAccessLayer.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(string employeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(string empID);
        bool Save();
    }
}
