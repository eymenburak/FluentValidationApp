using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidationApp.Models;
using FluentValidationApp.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Routing;

namespace FluentValidationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly FluentAppDbContext _context;
        private readonly IMapper _mapper;

        public StudentAPIController(FluentAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/StudentAPI
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetStudent()
        {
            List<Student> students =  await _context.Student.ToListAsync();

            return _mapper.Map<List<StudentDto>>(students);
        }
        [Route("Flat")]
        [HttpGet]
        public IActionResult Flat()
        {
            Student student = new Student { Id = 1, Name = "Eymen", Surname = "Vural", Class = 3, Telephone = new Telephone { Number = "222222", Brand = "Iphone" } };
            return Ok(_mapper.Map<StudentDto>(student));
        }
        // GET: api/StudentAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/StudentAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/StudentAPI
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/StudentAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
