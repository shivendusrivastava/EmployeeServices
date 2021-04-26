using Employee.Provider.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeServices.Controllers
{
    [Route("api/employee")]
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
        [Route("AddEmployee")]
        public IActionResult AddEmployee(Employee.DataAccessLayer.Employee employee)
        {
            employeeProvider.AddEmployee(employee);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee.DataAccessLayer.Employee employee)
        {
            employeeProvider.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(string empID)
        {
            employeeProvider.DeleteEmployee(empID);
            return Ok();
        }
    }
}
