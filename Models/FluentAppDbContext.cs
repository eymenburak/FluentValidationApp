using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidationApp.Models;

namespace FluentValidationApp.Models
{
    public class FluentAppDbContext : DbContext
    {
        public FluentAppDbContext(DbContextOptions<FluentAppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Student { get; set; }
       
    }
}
