using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidationApp.Models;
using FluentValidation;
using AutoMapper;
using FluentValidationApp.DTOs;

namespace FluentValidationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAPIController : ControllerBase
    {
        private readonly FluentAppDbContext _context;
        private readonly IValidator<Employee> _employeeValidator;
        private readonly IMapper _mapper;

        public EmployeesAPIController(FluentAppDbContext context, IValidator<Employee> employeeValidator, IMapper mapper)
        {
            _context = context;
            _employeeValidator = employeeValidator;
            _mapper = mapper;
        }

        // GET: api/EmployeesAPI
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployees()
        {
          List<Employee> employees =  await _context.Employees.ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        // GET: api/EmployeesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/EmployeesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeesAPI
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var result = _employeeValidator.Validate(employee);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x=> new { property = x.PropertyName, error = x.ErrorMessage }));
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/EmployeesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
