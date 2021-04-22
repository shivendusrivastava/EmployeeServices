using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeServices.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProvider employeeProvider;

        public EmployeeController(IEmployeeProvider employeeProvider)
        {
            this.employeeProvider = employeeProvider;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Employee.DataAccessLayer.Employee>> GetEmployees()
        {
            return employeeProvider.GetEmployees().ToList();
        }

        [HttpGet("{employeeId}")]
        public Employee.DataAccessLayer.Employee GetEmployee(string employeeId)
        {
            return employeeProvider.GetEmployee(employeeId);
        }

        [HttpPost]
        [Route("api/Employee/AddEmployee")]
        public IActionResult AddEmployee(Employee.DataAccessLayer.Employee employee)
        {
            employeeProvider.AddEmployee(employee);
            return Ok();
        }

        [HttpPost]
        [Route("api/Employee/UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee.DataAccessLayer.Employee employee)
        {
            employeeProvider.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete]
        [Route("api/Employee/DeleteEmployee")]
        public IActionResult DeleteEmployee(string empID)
        {
            employeeProvider.DeleteEmployee(empID);
            return Ok();
        }
    }
}
