using Employee.DataAccessLayer.DBContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee.DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(string employeeId)
        {
            return _context.Employees.SingleOrDefault(a => a.EmployeeID == employeeId);
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Add(employee);
            Save();
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            var entity = _context.Employees.Update(updatedEmployee);
            entity.State = EntityState.Modified;
            Save();
        }

        public void DeleteEmployee(string empID)
        {
            var employee = GetEmployee(empID);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            Save();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }


    }
}
