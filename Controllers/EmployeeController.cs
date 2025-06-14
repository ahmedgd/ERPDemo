using Microsoft.AspNetCore.Mvc;
using ERPDemo.Data;
using ERPDemo.Models;

namespace ERPDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }


        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }




        // ✅ POST: api/Employees
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee.DateOfJoining == default)
                employee.DateOfJoining = DateTime.UtcNow; // أو DateTime.Now حسب المنطقة الزمنية

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

    }
}
