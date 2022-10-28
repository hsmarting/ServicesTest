using Microsoft.AspNetCore.Mvc;
using ServiceTest.Entities;

namespace ServiceTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>();


        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet("All")]
        public async Task<ActionResult<Response<List<Employee>>>> GetEmployeeAll()
        {
            if(!_employees.Any())
                GetEmployee();

            return ResponseState<List<Employee>>.Ok(_employees, "Success", 0);
        }

        [HttpGet("ById/{idEmployee:int}")]
        public async Task<ActionResult<Response<Employee>>> GetEmployeeById(int idEmployee)
        {
            if (!_employees.Any())
                GetEmployee();

            var item = _employees.First(p => p.IdEmployee == idEmployee);
            return ResponseState<Employee>.Ok(item, "Success", 0);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Response<bool>>> AddEmployee([FromBody] Employee employee)
        {
            if (!_employees.Any())
                GetEmployee();

            if (employee.IdEmployee == 0)
            {
                employee.IdEmployee = _employees.Count() + 1;
                _employees.Add(employee);
            }
            else 
            {
                _employees.Where(p => p.IdEmployee == employee.IdEmployee).Select(p =>
                {
                    p.FirstName = employee.FirstName;
                    p.LastName = employee.LastName;
                    p.Address = employee.Address;
                    p.Email = employee.Email;
                    p.PhoneNumber = employee.PhoneNumber;
                    return p;
                }).ToList();
            }
            
            return ResponseState<bool>.Ok("Success");
        }       

        [HttpPost("Delete/{idEmployee:int}")]
        public async Task<ActionResult<Response<bool>>> DeleteEmployee(int idEmployee) 
        {
            if (!_employees.Any())
                GetEmployee();

            var item = _employees.First(p => p.IdEmployee == idEmployee);
            _employees.Remove(item);

            return ResponseState<bool>.Ok("Success");
        }

        #region Methods Bussines
        private void GetEmployee() 
        {
            _employees.Add(new Employee { IdEmployee = 1, Address = "Desconocida", Email = "hsmarting@gmail.com", FirstName = "Humberto", LastName = "San Martin", PhoneNumber = "1234567890" });
            _employees.Add(new Employee { IdEmployee = 2, Address = "Desconocida", Email = "hsmarting@gmail.com", FirstName = "Bryan", LastName = "San Martin", PhoneNumber = "1234567890" });
            _employees.Add(new Employee { IdEmployee = 3, Address = "Desconocida", Email = "hsmarting@gmail.com", FirstName = "Pedro", LastName = "Rodrigues Morales", PhoneNumber = "1234567890" });
            _employees.Add(new Employee { IdEmployee = 4, Address = "Desconocida", Email = "hsmarting@gmail.com", FirstName = "Mauricio", LastName = "Santes Salinas", PhoneNumber = "1234567890" });
        }

        #endregion
    }
}