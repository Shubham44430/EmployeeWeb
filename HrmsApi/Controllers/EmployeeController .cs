using Microsoft.AspNetCore.Mvc;
using HrmsApi.Models;

namespace HrmsApi.Controllers
{
    [ApiController]
    [Route("hrms")]
    public class EmployeeController : ControllerBase
    {
        private readonly HrmsDbContext emp;

        public EmployeeController(HrmsDbContext emp)
        {
            this.emp = emp;
        }

        //http://localhost:5000/hrms/all

        [HttpGet("all")]
        public IActionResult GetAllEmployees()
        {
            return Ok(emp.Employees.ToList());
        }

        //http://localhost:5000/hrms/101
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = emp.Employees.Find(id);

            if (employee == null)
                return NotFound("No Employee of this Id");

            return Ok(employee);
        }

        //http://localhost:5000/hrms/

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee emp1)
        {
            emp.Employees.Add(emp1);
            emp.SaveChanges();

            return Created("", "Employee created successfully");
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] Employee emp2)
        {
            var employee = emp.Employees.Find(id);
            if (employee == null)
                return NotFound("No Employee of this Id");

            // ✅ Update DB entity using request data
            employee.Name = emp2.Name;
            employee.Salary = emp2.Salary;

            emp.SaveChanges();   // ✅ No Update() needed

            return Ok(employee);
        }


    }
}