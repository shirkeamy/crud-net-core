using crud_net_core.DataServices;
using crud_net_core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud_net_core.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeServices employeeServices;
        public EmployeeController()
        {
            employeeServices = new EmployeeServices();
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            var employees = employeeServices.GetEmployees();
            
            if (!employees.Any()) { 
                return NoContent();
            }
            
            return Ok(employees);
        }
        
        [HttpGet("employeeId")]
        public ActionResult GetEmployee(int employeeId)
        {
            if (employeeId <= 0) {
                return BadRequest("Employee Id must be positive integer only");
            }
            
            var employees = employeeServices.GetEmployee(employeeId);
            
            if(employees.EmployeeId == 0)
            {
                return NotFound($"There is no employee found with employeeId - {employeeId}");
            }

            return Ok(employees);
        }

        [HttpPost]
        public ActionResult InsertEmployeeData([FromBody]Employee employee)
        {
            employeeServices.InsertEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("employeeId")]
        public ActionResult UpdateEmployeeData(int employeeId, Employee employee)
        {
            employeeServices.UpdateEmployee(employeeId, employee);
            return Ok(employee);
        }

        [HttpDelete("employeeId")]
        public ActionResult DeleteEmployeeData(int employeeId)
        {
            int res = employeeServices.DeleteEmployee(employeeId);
            return Ok(res);
        }
    }
}
